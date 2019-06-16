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
    public class EfGetForWebCommand : EfBaseCommand, IGetForWebCommand
    {
        public EfGetForWebCommand(LibraryContext _context) : base(_context)
        {
        }

        public BookDto Execute(int request)
        {
            

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
                    WriterId = b.WriterId,
                    Description = b.Description,
                    AvailableCount = b.AvailableCount,
                    Count = b.Count,
                    BookGenres = b.BookGenres.Select(bg => bg.Genre.Name)
                }).FirstOrDefault();

            var genres = book.BookGenres;

            string allGenres = null;

            foreach(var genre in genres)
            {
                allGenres += genre + ", ";
            }

            book.Genre = allGenres;

            if (book == null)
            {
                throw new EntityNotFoundException("book");
            }

            return book;
        }
    }
}
