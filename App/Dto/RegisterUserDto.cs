using System.ComponentModel.DataAnnotations;
using TaskManager.App.Repositories;
using TaskManager.App.Services;
using TaskManager.App.Validation;

namespace TaskManager.App.Dto
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "The name field is required")]
        [MinLength(2, ErrorMessage = "The length of the name should have at least 2 characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "The email field is required")]
        [EmailAddress]
        [UniqueEmail]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "The name field is required")]
        [MinLength(6, ErrorMessage = "The length of the name should have at least 6 characters")]
        public string Password { get; set; }
    }
}