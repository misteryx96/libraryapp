using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime? DateTaken { get; set; } //Date when an User took a book
        public DateTime? DateToReturn { get; set; } //Date when an User needs to return a Book
        public DateTime? DateCreated { get; set; } //Not using when making object, only for showing
        public DateTime? DateExpiry { get; set; } //Not using when making object, only for showing
        [Required(ErrorMessage = "Field is Required")] public int UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<int> BookReservations { get; set; }
        public IEnumerable<string> Books { get; set; }
        public string BooksSelected { get; set; }
    }
}
