using Application.Commands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfAddUserCommand : EfBaseCommand, IAddUserCommand
    {
        public EfAddUserCommand(LibraryContext _context) : base(_context) { }

        public void Execute(UserDto request)
        {
            if(_context.Users.Any(u => u.UserName == request.UserName))
            {
                throw new Exception();
            }

            _context.Users.Add(new Domain.User
            {
                FirstName = request.FirstName,
                UserName = request.UserName,
                LastName = request.LastName,
                Password = request.Password,
                RoleId = (int)request.RoleId,
                CreatedAt = DateTime.Now
            });

            _context.SaveChanges();
        }
    }
}
