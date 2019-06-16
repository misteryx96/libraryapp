using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfUpdateWriterCommand : EfBaseCommand, IUpdateWriterCommand
    {
        public EfUpdateWriterCommand(LibraryContext _context) : base(_context) { }
        public void Execute(WriterDto request)
        {
            var writer = _context.Writers.Find(request.Id);

            if (writer == null)
            {
                throw new EntityNotFoundException("writer");
            }

            if(writer.Name != request.Name)
            {
                if(_context.Writers.Any(w => w.Name == request.Name))
                {
                    throw new EntityAlreadyExistsException("writer");
                }   
            }

            //writer.Id = (int)request.Id;
            writer.Name = request.Name;
            writer.ModifiedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
