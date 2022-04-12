using System.ComponentModel.DataAnnotations;
using TaskManager.App.Services;

namespace TaskManager.App.Validation
{
    public class UniqueEmail: ValidationAttribute
    {
        private readonly UserService _userService = new UserService();
        private string GetErrorMessage() => "The email is already in use";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return _userService.EmailExists(value.ToString()) ? new ValidationResult(GetErrorMessage()) : ValidationResult.Success;
        }
    }
}