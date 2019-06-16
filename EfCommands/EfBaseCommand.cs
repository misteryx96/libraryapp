using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public abstract class EfBaseCommand
    {
        protected EfBaseCommand(LibraryContext context)
        {
            _context = context;
        }

        protected LibraryContext _context { get; }
    }
}
