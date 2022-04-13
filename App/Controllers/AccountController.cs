using System;
using Microsoft.AspNetCore.Mvc;
using TaskManager.App.Dto;
using TaskManager.App.Services;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

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
            
            return Ok(new { message = "User has been created successfully" });
        }
        
        
        [HttpPost("login")]
        public ActionResult<dynamic> Login([FromBody] LoginUserDto request)
        {
            UserDto userDto = _userService.Authenticate(request);

            if (userDto is null)
            {
                ModelState.AddModelError("Email", "The credentials you provided do not match with our records");
                return BadRequest(new { errors = ModelState.ToJson() });
            }

            return Ok(new { });
        }
    }
}