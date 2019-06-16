using Application.Commands;
using Application.DTO;
using Application.Responses;
using Application.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetPagedBooksCommand : EfBaseCommand, IGetPagedBooksCommand
    {
        public EfGetPagedBooksCommand(LibraryContext _context) : base(_context)
        {

        }

        public PagedResponse<BookDto> Execute(BookSearch request)
        {
            var query = _context.Books.AsQueryable();

            if (request.BookName != null)
            {
                var keyword = request.BookName.ToLower();
                query = query.Where(b => b.Title.ToLower().Contains(keyword));
            }
            if (request.IsAvailable)
            {
                query = query.Where(b => b.AvailableCount > 0);
            }
            if (request.GenreId != null)
            {
                query = query.Where(b => b.BookGenres.Any(bg => bg.GenreId == request.GenreId));
            }
                var totalCount = query.Count();
                query = query
                    .Include(b => b.Writer)
                    .ThenInclude(w => w.Name)
                    .Include(b => b.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                    .Skip((request.PageNumber - 1) * request.PerPage)
                    .Take(request.PerPage);
            

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedResponse<BookDto> {
                CurrentPage = request.PageNumber,
                TotalCount = query.Count(),
                PagesCount = pagesCount,
                Data = query.Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Writer = b.Writer.Name,
                    Description = b.Description,
                    AvailableCount = b.AvailableCount,
                    Count = b.Count,
                    BookGenres = b.BookGenres.Select(bg => bg.Genre.Name)
                })
            };
            return response;
        }
    }
}
