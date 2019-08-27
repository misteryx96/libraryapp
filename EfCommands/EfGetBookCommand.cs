using Application.Commands;
using Application.DTO;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;

namespace EfCommands
{
    public class EfGetBookCommand : EfBaseCommand, IGetBookCommand
    {
        public EfGetBookCommand(LibraryContext _context) : base(_context) { }
        public BookDto Execute(int request)
        {
            //var book = _context.Books.AsQueryable();
            var book = _context.Books
                .Where(b => b.Id == request)
                .Include(b => b.Writer)
                .ThenInclude(w => w.Name)
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Writer = b.Writer.Name,
                    Description = b.Description,
                    AvailableCount = b.AvailableCount,
                    Count = b.Count,
                    BookGenres = b.BookGenres.Select(bg => bg.Genre.Name)
                }).FirstOrDefault();

            if (book == null)
            {
                throw new EntityNotFoundException("book");
            }

            return book;

        }
    }
}
