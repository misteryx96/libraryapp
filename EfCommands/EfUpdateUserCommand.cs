using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfUpdateUserCommand : EfBaseCommand, IUpdateUserCommand
    {
        public EfUpdateUserCommand(LibraryContext _context) : base(_context)
        {
        }

        public void Execute(UserDto request)
        {
            var user = _context.Users.Find(request.Id);

            bool isChanged = false;

            if (user == null)
            {
                throw new EntityNotFoundException("user");
            }

            if (user.FirstName != request.FirstName)
                isChanged = true;
            if (user.LastName != request.LastName)
                isChanged = true;
            if (user.RoleId != request.RoleId)
                isChanged = true;
            if (user.UserName != request.UserName)
                isChanged = true;

            if (isChanged)
            {
                user.UserName = request.UserName;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.RoleId = (int)request.RoleId;
                user.ModifiedAt = DateTime.Now;
                _context.SaveChanges();
            }

            
        }
    }
}
