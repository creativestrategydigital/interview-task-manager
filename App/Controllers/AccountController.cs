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
        public ActionResult<HttpSuccessResponse> Register([FromBody] RegisterUserRequest request)
        {
            _userService.CreateNewUser(request);
            
            return CreatedAtAction(nameof(Login), new HttpSuccessResponse{ Message = "User has been created successfully"});
        }
        
        
        [HttpPost("login")]
        public ActionResult<UserDto> Login([FromBody] LoginUserRequest request)
        {
            UserDto userDto = _userService.Authenticate(request);

            if (userDto is null)
            {
                ModelState.AddModelError("Email", "The credentials you provided do not match with our records");
                return BadRequest(new { errors = ModelState.ToJson() });
            }

            return Ok(userDto);
        }
    }
}