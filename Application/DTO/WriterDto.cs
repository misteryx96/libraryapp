using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class WriterDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Field Name is Required")][RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage ="Required field is not in a good format")]public string Name { get; set; } //Should be in format Name + Surname
    }
}
