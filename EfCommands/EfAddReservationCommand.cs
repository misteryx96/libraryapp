using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfAddReservationCommand : EfBaseCommand, IAddReservationCommand
    {
        public EfAddReservationCommand(LibraryContext _context) : base(_context)
        {
        }

        public void Execute(ReservationDto request)
        {
            if((_context.Reservations.Any(r => r.UserId == request.UserId)))
            {
                throw new EntityAlreadyExistsException("reservation");
            }

            TimeSpan addedTime = new TimeSpan(72, 0, 0);

            var selectedBooks = request.BookReservations;

            var reservation = new Domain.Reservation
            {
                CreatedAt = DateTime.Now,
                DateExpiry = DateTime.Now.Add(addedTime),
                UserId = request.UserId
            };

            var books = new List<Domain.BookReservation>();

            foreach(var b in selectedBooks)
            {
                var bookReservation = new Domain.BookReservation
                {
                    ReservationId = reservation.Id,
                    BookId = b
                };

                books.Add(bookReservation);
            }

            reservation.BookReservations = books;

            _context.Reservations.Add(reservation);

            _context.SaveChanges();

        }
    }
}
