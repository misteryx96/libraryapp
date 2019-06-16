using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfDeleteBookCommand : EfBaseCommand, IDeleteBookCommand
    {
        public EfDeleteBookCommand(LibraryContext _context) : base(_context) { }

        public void Execute(int request)
        {
            var book = _context.Books.Where(b => b.Id == request).Select(b => b).FirstOrDefault();

            if(book == null)
            {
                throw new EntityNotFoundException("book");
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
