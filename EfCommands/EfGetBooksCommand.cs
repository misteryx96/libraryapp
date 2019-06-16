using Application.Commands;
using Application.DTO;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCommands
{
    public class EfGetBooksCommand : EfBaseCommand, IGetBooksCommand
    {

        public EfGetBooksCommand(LibraryContext _context) : base(_context) { }

        public IEnumerable<BookDto> Execute(BookSearch request)
        {
            var query = _context.Books.AsQueryable();

            if(request.BookName != null)
            {
                var keyword = request.BookName.ToLower();
                query = query.Where(b => b.Title.ToLower().Contains(keyword));
            }
            if (request.IsAvailable)
            {
                query = query.Where(b => b.AvailableCount > 0);
            }

            return query
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
                });
        }
    }
}
