using Application.Commands;
using Application.DTO;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfGetWritersCommand : EfBaseCommand, IGetWritersCommand
    {
        public EfGetWritersCommand(LibraryContext _context) : base(_context) { }
        public IEnumerable<WriterDto> Execute(WriterSearch request)
        {
            var query = _context.Writers.AsQueryable();

            if(request.Name != null)
            {
                var keyword = request.Name.ToLower();
                query = query.Where(w => w.Name.ToLower().Contains(keyword));
            }

            return query
                .Select(w => new WriterDto
                {
                    Name = w.Name
                });
        }
    }
}
