using Application.Commands;
using Application.DTO;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfCreateBookCommand : EfBaseCommand, ICreateBookCommand
    {
        public EfCreateBookCommand(LibraryContext _context) : base(_context)
        {
        }

        public void Execute(BookDto request)
        {
            if (_context.Books.Any(b => b.Title == request.Title))
            {
                throw new Exception(); //IF BOOK WITH THE SAME NAME EXISTS
            }

            if (!(_context.Writers.Any(w => w.Id == request.WriterId)))
            {
                throw new Exception(); //IF WRITER WITH THAT ID DOES NOT EXIST
            }

            var book = new Domain.Book
            {
                Title = request.Title,
                Description = request.Description,
                AvailableCount = request.AvailableCount,
                Count = request.Count,
                WriterId = request.WriterId,
                CreatedAt = DateTime.Now
            };

            var genre = request.Genre;

            var allGenres = new List<string>();

            var idsForGenres = new List<int>();

            var allGenresThatExists = _context.Genres.ToList();

            allGenres = genre.Split(',', ' ').ToList();

            foreach (var g in allGenres)
            {
                foreach (var G in allGenresThatExists)
                {
                    if (G.Name == g)
                    {
                        idsForGenres.Add(G.Id);
                    }
                }
            }

            var bookGenres = new List<BookGenre>();

            foreach (int gId in idsForGenres)
            {
                var bookGenre = new Domain.BookGenre
                {
                    BookId = book.Id,
                    GenreId = gId
                };

                bookGenres.Add(bookGenre);
            }

                book.BookGenres = bookGenres;

                _context.Books.Add(book);

                _context.SaveChanges();
        }
    }
}
