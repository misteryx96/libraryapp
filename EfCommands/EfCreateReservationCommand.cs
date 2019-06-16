using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfCreateReservationCommand : EfBaseCommand, ICreateReservationCommand
    {
        public EfCreateReservationCommand(LibraryContext _context) : base(_context)
        {
        }

        public void Execute(ReservationDto request)
        {
            if ((_context.Reservations.Any(r => r.UserId == request.UserId)))
            {
                throw new EntityAlreadyExistsException("reservation");
            }

            TimeSpan addedTime = new TimeSpan(72, 0, 0);

            var reservation = new Domain.Reservation
            {
                CreatedAt = DateTime.Now,
                DateExpiry = DateTime.Now.Add(addedTime),
                UserId = request.UserId
            };

            var books = request.BooksSelected;

            var allBooks = new List<string>();

            var idsForBooks = new List<int>();

            var allBooksThatExists = _context.Books.ToList();

            allBooks = books.Split(", ").ToList();

            foreach (var b in allBooks)
            {
                foreach (var B in allBooksThatExists)
                {
                    if (B.Title == b)
                    {
                        idsForBooks.Add(B.Id);
                    }
                }
            }

            var bookReservations = new List<BookReservation>();

            foreach (int bId in idsForBooks)
            {
                var bookReservation = new Domain.BookReservation
                {
                    ReservationId = reservation.Id,
                    BookId = bId
                };

                bookReservations.Add(bookReservation);
            }

            reservation.BookReservations = bookReservations;

            _context.Reservations.Add(reservation);

            _context.SaveChanges();
        }
    }
}
