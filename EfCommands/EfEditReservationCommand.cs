using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfEditReservationCommand : EfBaseCommand, IEditReservationCommand
    {
        public EfEditReservationCommand(LibraryContext _context) : base(_context)
        {
        }

        public void Execute(ReservationDto request)
        {
            var reservation = _context.Reservations.Where(r => r.Id == request.Id)
                                                    .Include(r => r.BookReservations)
                                                    .ThenInclude(br => br.Book)
                                                    .FirstOrDefault();

            if (reservation == null)
            {
                throw new EntityNotFoundException("reservation");
            }

            var selectedBooks = reservation.BookReservations;

            foreach (Domain.BookReservation br in selectedBooks)
            {
                _context.Entry(br).State = EntityState.Deleted;
            }

            _context.SaveChanges();

            

            var bookReservations = new List<BookReservation>();

            var book = request.BooksSelected;

            var allBooks = new List<string>();

            var idsForBooks = new List<int>();

            var allBooksThatExist = _context.Books.ToList();

            allBooks = book.Split(", ").ToList();

            foreach(var b in allBooks)
            {
                foreach(var B in allBooksThatExist)
                {
                    if(B.Title == b)
                    {
                        idsForBooks.Add(B.Id);
                    }
                }
            }

            foreach(int bId in idsForBooks)
            {
                var bookReservation = new Domain.BookReservation
                {
                    ReservationId = reservation.Id,
                    BookId = bId
                };

                bookReservations.Add(bookReservation);
            }

            reservation.BookReservations = bookReservations;

            reservation.UserId = request.UserId;

            reservation.ModifiedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
