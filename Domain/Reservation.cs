using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Reservation : BaseEntity
    {
        //DateCreated is already in BaseEntity
        public DateTime DateExpiry { get; set; } //Date when the Reservation is going to expire
        public DateTime DateTaken { get; set; } //Date when an User took a book
        public DateTime DateToReturn { get; set; } //Date when an User needs to return a Book
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<BookReservation> BookReservations { get; set; }
    }
}
