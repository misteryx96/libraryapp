using Application.Commands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfAddBookCommand : EfBaseCommand, IAddBookCommand
    {

        public EfAddBookCommand(LibraryContext _context) : base(_context) { }

        public void Execute(BookDto request)
        {

            if (_context.Books.Any(b => b.Title == request.Title))
            {
                throw new Exception();
            }

            if (!(_context.Writers.Any(w => w.Id == request.WriterId)))
            {
                throw new Exception();
            }

            //if (!(_context.Genres.Any(g => g.Id == request.GenreId)))
            //{
            //    throw new Exception();
            //}

            //var genres = request.BookGenres.Select(bg => new Domain.Genre
            //{
            //    Name = bg
            //});

            var genres = request.SelectedGenres;

            var book = new Domain.Book
            {
                Title = request.Title,
                Description = request.Description,
                AvailableCount = request.AvailableCount,
                Count = request.Count,
                WriterId = request.WriterId,
                CreatedAt = DateTime.Now
            };

            var bookGenres = new List<Domain.BookGenre>();

            foreach (int g in genres)
            {
                var bookGenre = new Domain.BookGenre
                {
                    BookId = book.Id,
                    GenreId = g
                };

                bookGenres.Add(bookGenre);
            }

            book.BookGenres = bookGenres;

            //var bookGenres = new List<Domain.Genre>();

            //var bookGenres = genres.Select(g => new Domain.BookGenre {
            //    Genre = g,
            //    Book = book
            //});

            //book.BookGenres = bookGenres.ToList();

            _context.Books.Add(book);

            _context.SaveChanges();

        } }}


