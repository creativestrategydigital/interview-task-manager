using Microsoft.AspNetCore.Mvc;
using TaskManager.App.Dto;
using TaskManager.App.Services;

namespace TaskManager.App.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AccountController : ControllerBase
    {
        private readonly UserService _userService = new UserService();
        
        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterUserDto request)
        {
            _userService.CreateNewUser(request);
            
            return Ok(new {message = "User has been created successfully"});
        }
    }
}