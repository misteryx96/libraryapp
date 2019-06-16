using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class UserDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="Field is required!")][RegularExpression("^[a-z0-9_-]{3,16}$", ErrorMessage ="Not in a good format!")]public string UserName { get; set; }
        [Required(ErrorMessage = "Field is required!")][RegularExpression("^[A-Z]{1}[a-z]{2,15}$", ErrorMessage ="Not in a good format")]public string FirstName { get; set; }
        [Required(ErrorMessage = "Field is required!")][MinLength(8, ErrorMessage ="Password is too short! Should have at leas 8 chars")]public string Password { get; set; } // Should consider this tho
        [Required(ErrorMessage = "Field is required!")][RegularExpression("^[A-Z]{1}[a-z]{2,15}$", ErrorMessage = "Not in a good format")] public string LastName { get; set; }
        [Required(ErrorMessage = "Field is required!")] public int? RoleId { get; set; }
        public string Role { get; set; }

    }
}
