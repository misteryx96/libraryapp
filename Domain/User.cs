using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
