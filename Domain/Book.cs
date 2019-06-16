using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int? WriterId { get; set; }
        public Writer Writer { get; set; }
        public string Description { get; set; }
        public int AvailableCount { get; set; } //available for Reservation
        public int Count { get; set; } //all books regardless whether reserved or not
        //public ICollection<int> SelectedGenres { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
        public ICollection<BookReservation> BookReservations { get; set; }
    }
}
