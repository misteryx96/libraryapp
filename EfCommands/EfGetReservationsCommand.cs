using Application.Commands;
using Application.DTO;
using Application.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetReservationsCommand : EfBaseCommand, IGetReserervationsCommand
    {
        public EfGetReservationsCommand(LibraryContext _context) : base(_context)
        {
        }

        public IEnumerable<ReservationDto> Execute(ReservationSearch request)
        {
            var query = _context.Reservations.AsQueryable();

            //var user = _context.Users.Where(u => u.UserName == request.UserName).ToString();

            if(request.UserName != null)
            {
                var keyword = request.UserName.ToLower();
                query = query.Where(r => r.User.UserName.ToLower().Contains(keyword));
            }

            return query
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
                }) ;
        }
    }
}
