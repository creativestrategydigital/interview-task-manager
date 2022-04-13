using System.ComponentModel.DataAnnotations;
using TaskManager.App.Services;

namespace TaskManager.App.Validation
{
    public class EmailExists : ValidationAttribute
    {
        private readonly UserService _userService = new UserService();
        private string GetErrorMessage() => "The credentials you provided do not match with our records";
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return _userService.EmailExists(value.ToString()) ? ValidationResult.Success : new ValidationResult(GetErrorMessage());
        }
    }
}