using System.ComponentModel.DataAnnotations;
using TaskManager.App.Validation;

namespace TaskManager.App.Dto
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        [EmailExists]
        public string Email { get; set; }
        
        [Required]
        [MinLength(8, ErrorMessage = "The password must have at least 8 characters ")]
        public string Password { get; set; }
    }
}