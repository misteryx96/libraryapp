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
    public class EfUpdateBookCommand : EfBaseCommand, IUpdateBookCommand
    {
        public EfUpdateBookCommand(LibraryContext _context) : base(_context)
        {
        }

        public void Execute(BookDto request)
        {
            //var book = _context.Books.Find(request.Id);

            var book = _context.Books.Where(b => b.Id == request.Id)
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .FirstOrDefault();

            bool isChanged = false;

            if(book == null)
            {
                throw new EntityNotFoundException("book");
            }

            if (book.Title != request.Title)
                isChanged = true;
            if (book.WriterId != request.WriterId)
                isChanged = true;

            if (isChanged)
            {
                book.Title = request.Title;
                book.WriterId = request.WriterId;
                book.AvailableCount = request.AvailableCount;
                book.Count = request.Count;
                book.Description = request.Description;
                book.ModifiedAt = DateTime.Now;

                var bookGenres = new List<Domain.BookGenre>();
                var genres = request.SelectedGenres;
                var selectedGenres = book.BookGenres;

                foreach (Domain.BookGenre bg in selectedGenres)
                {
                    //book.BookGenres.Remove(bg);
                    
                    _context.Entry(bg).State = EntityState.Deleted;
                }

                _context.SaveChanges();

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

                _context.SaveChanges();
            }
        }
    }
}
