using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfEditBookCommand : EfBaseCommand, IEditBookCommand
    {
        public EfEditBookCommand(LibraryContext _context) : base(_context)
        {
        }

        public void Execute(BookDto request)
        {
            var book = _context.Books.Where(b => b.Id == request.Id)
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .FirstOrDefault();

            bool isChanged = false;

            if (book == null)
            {
                throw new EntityNotFoundException("book");
            }

            if (book.Title != request.Title)
                isChanged = true;
            if (book.WriterId != request.WriterId)
                isChanged = true;
            //if (!(_context.Genres.Any(g => g.Name == request.Genre)))
            //{
            //    throw new Exception();
            //}

            if (isChanged)
            {
                book.Title = request.Title;
                book.WriterId = request.WriterId;
                book.AvailableCount = request.AvailableCount;
                book.Count = request.Count;
                book.Description = request.Description;
                book.ModifiedAt = DateTime.Now;

                var bookGenreSelected = book.BookGenres;

                //var genreId = _context.Genres.Where(g => g.Name == request.Genre).Select(g => g.Id).FirstOrDefault();

                foreach (Domain.BookGenre bg in bookGenreSelected)
                {
                    _context.Entry(bg).State = EntityState.Deleted;
                }

                _context.SaveChanges();

                var bookGenres = new List<BookGenre>();

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

                _context.SaveChanges();

                //var bookGenre1 = new Domain.BookGenre
                //{
                //    GenreId = genreId,
                //    BookId = book.Id
                //};

                //bookGenre.Add(bookGenre1);

                //book.BookGenres = bookGenre;

                //_context.SaveChanges();
            }
        }
    }
}
