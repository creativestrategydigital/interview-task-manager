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

        public User CreateNewUser(RegisterUserRequest request)
        {
            var newUser = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                ApiToken = Helpers.GenerateRandomString(50)
            };
            
            _userRepository.Save(newUser);

            return newUser;
        }

        public UserDto? Authenticate(LoginUserRequest request)
        {
            User user = _userRepository.FindByEmail(request.Email);
            
            if(! BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return null;
            }
            
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                ApiToken = user.ApiToken
            };
        }
    }
}