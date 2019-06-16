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
    public class EfGetReservationCommand : EfBaseCommand, IGetReservationCommand
    {
        public EfGetReservationCommand(LibraryContext _context) : base(_context)
        {
        }

        public ReservationDto Execute(int request)
        {
            var reservation = _context.Reservations
                .Where(r => r.Id == request)
                .Include(r => r.BookReservations)
                .ThenInclude(br => br.Book)
                .Include(r => r.User)
                .ThenInclude(u => u.UserName)
                .Select(r => new ReservationDto
                {
                    Id = r.Id,
                    DateCreated = r.CreatedAt,
                    DateExpiry = r.DateExpiry,
                    DateTaken = r.DateTaken,
                    DateToReturn = r.DateToReturn,
                    UserName = r.User.UserName,
                    UserId = r.User.Id,
                    Books = r.BookReservations.Select(br => br.Book.Title)
                }).FirstOrDefault();

            if(reservation == null)
            {
                throw new EntityNotFoundException("reservation");
            }

            return reservation;
        }
    }
}
