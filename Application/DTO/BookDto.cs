using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field Title is Required")] [StringLength(50, ErrorMessage ="Book Title is not in a good format")]public string Title { get; set; }
        public string Writer { get; set; }
        public int? WriterId { get; set; }
        public int? GenreId { get; set; }
        [Required(ErrorMessage = "Field is Required")] [StringLength(1000, ErrorMessage ="Description is too long!")]public string Description { get; set; }
        [Required(ErrorMessage = "Field is Required")] public int AvailableCount { get; set; } //available for Reservation
        [Required(ErrorMessage = "Field is Required")] public int Count { get; set; } //all books regardless whether reserved or not
        public IEnumerable<string> BookGenres { get; set; }
        public IEnumerable <int> SelectedGenres { get; set; }
        public string Genre { get; set; } //using only for adding a book in WebApp
        //public IEnumerable<string> BookReservations { get; set; }
    }
}
