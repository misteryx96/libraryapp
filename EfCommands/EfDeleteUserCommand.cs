using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfDeleteUserCommand : EfBaseCommand, IDeleteUserCommand
    {
        public EfDeleteUserCommand(LibraryContext context) : base(context)
        {
        } 
        public void Execute(int request)
        {
            var user = _context.Users.Find(request);

            if(user == null)
            {
                throw new EntityNotFoundException("user");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
