using Application.Commands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfAddWriterCommand : EfBaseCommand, IAddWriterCommand
    {
        public EfAddWriterCommand(LibraryContext _context) : base(_context) { }

        public void Execute(WriterDto request)
        {
            if(_context.Writers.Any(w => w.Name == request.Name))
            {
                throw new Exception();
            }

            _context.Writers.Add(new Domain.Writer
            {
                Name = request.Name,
                CreatedAt = DateTime.Now
            });

            _context.SaveChanges();
        }
    }
}
