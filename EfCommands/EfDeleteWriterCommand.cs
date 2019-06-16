using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteWriterCommand : EfBaseCommand, IDeleteWriterCommand
    {
        public EfDeleteWriterCommand(LibraryContext _context) : base(_context) { }
        public void Execute(int request)
        {
            var writer = _context.Writers.Find(request);
            
            if(writer == null)
            {
                throw new EntityNotFoundException("writer");
            }

            _context.Writers.Remove(writer);
            _context.SaveChanges();
        }
    }
}
