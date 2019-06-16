using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BookReservation
    {
        public int ReservationId { get; set; }
        public int BookId { get; set; }
        public Reservation Reservation { get; set; }
        public Book Book { get; set; }
    }
}
