using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfGetWriterCommand : EfBaseCommand, IGetWriterCommand
    {
        public EfGetWriterCommand(LibraryContext _context) : base(_context)
        {
        }

        public WriterDto Execute(int request)
        {
            var writer = _context.Writers.Find(request);

            if(writer == null)
            {
                throw new EntityNotFoundException("writer");
            }

            return new WriterDto
            {
                Name = writer.Name
            };
        }
    }
}
