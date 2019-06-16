using Application.Commands;
using Application.DTO;
using Application.Interfaces;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfTookABookCommand : EfBaseCommand, ITookABookCommand
    {
        private readonly IEmailSender emailSender;

        public EfTookABookCommand(LibraryContext _context, IEmailSender emailSender) : base(_context)
        {
            this.emailSender = emailSender;
        }

        

        public void Execute(int request)
        {
            var reservation = _context.Reservations.Find(request);

            reservation.DateTaken = DateTime.Now;

            TimeSpan addedTime = new TimeSpan(504, 0, 0);

            reservation.DateToReturn = DateTime.Now.Add(addedTime);

            var date = reservation.DateToReturn;

            var reserved = _context.Reservations.Include(r => r.BookReservations).ThenInclude(br => br.Book)
                .Where(b => b.Id == request).FirstOrDefault();

            var re = reserved.BookReservations;

            var book = new Domain.Book();

            foreach (var r in re)
            {
                book = _context.Books.Find(r.BookId);
                book.AvailableCount = book.AvailableCount - 1;
            }

            _context.SaveChanges();

            emailSender.Body = "Do not respond to this email. It is an automatic email. You should return your book until " + date;

            emailSender.Subject = "libraryApp";

            emailSender.ToEmail = "netcoreict@gmail.com";

            emailSender.Send();

        }
    }
}
