using System;
using Microsoft.AspNetCore.Http;
using TaskManager.App.Entities;
using TaskManager.App.Repositories;

namespace TaskManager.App.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository = new UserRepository();
        private readonly HttpContextAccessor _httpContextAccessor = new HttpContextAccessor();

        public User? Authenticate(string token)
        {
            User user = _userRepository.FindByApiToken(token);

            return user;
        }

        public User? CurrentUser()
        {
            string userId = _httpContextAccessor.HttpContext.User.Identity.Name;
            return _userRepository.FindById(Convert.ToInt32(userId));
        }
    }
}