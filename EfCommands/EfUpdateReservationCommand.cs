using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfUpdateReservationCommand : EfBaseCommand, IUpdateReservationCommand
    {
        public EfUpdateReservationCommand(LibraryContext _context) : base(_context)
        {
        }

        public void Execute(ReservationDto request)
        {
            var reservation = _context.Reservations.Where(r => r.Id == request.Id)
                .Include(r => r.BookReservations)
                .ThenInclude(br => br.Book)
                .FirstOrDefault();

            if(reservation == null)
            {
                throw new EntityNotFoundException("reservation");
            }

            var bookReservations = new List<Domain.BookReservation>();
            var books = request.BookReservations;
            var selectedBooks = reservation.BookReservations;

            foreach(Domain.BookReservation br in selectedBooks)
            {
                _context.Entry(br).State = EntityState.Deleted;
            }

            _context.SaveChanges();

            foreach(int b in books)
            {
                var bookReservation = new Domain.BookReservation
                {
                    BookId = b,
                    ReservationId = reservation.Id
                };

                bookReservations.Add(bookReservation);
            }

            reservation.BookReservations = bookReservations;

            reservation.ModifiedAt = DateTime.Now;

            _context.SaveChanges();

        }
    }
}
