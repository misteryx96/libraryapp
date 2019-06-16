using Application.Commands;
using Application.DTO;
using Application.Interfaces;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetGenresCommand : EfBaseCommand, IGetGenresCommand
    {
        public EfGetGenresCommand(LibraryContext _context) : base(_context)
        {
        }

        public IEnumerable<GenreDto> Execute(GenreSearch request)
        {
            var query = _context.Genres.AsQueryable();

            if (request.Name != null)
            {
                var keyword = request.Name.ToLower();
                query = query.Where(w => w.Name.ToLower().Contains(keyword));
            }

            return query
                .Select(w => new GenreDto
                {
                    Id = w.Id,
                    Name = w.Name
                });
        }
    }
}
