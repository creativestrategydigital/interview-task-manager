using System;
using TaskManager.App.Dto;
using TaskManager.App.Entities;
using TaskManager.App.Repositories;

namespace TaskManager.App.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository = new UserRepository();
        
  
        public bool EmailExists(string email)
        {
            var user = _userRepository.FindByEmail(email); 
            
            return ! (user is null);
        }

        public User CreateNewUser(RegisterUserDto request)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                ApiToken = Helpers.GenerateRandomString(50)
            };
            
            _userRepository.SaveUser(user);

            return user;
        }

        public UserDto? Authenticate(LoginUserDto request)
        {
            return null;
            
            return new UserDto();
        }
    }
}