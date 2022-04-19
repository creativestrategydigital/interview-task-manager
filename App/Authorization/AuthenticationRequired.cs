using System;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskManager.App.Entities;
using TaskManager.App.Services;

namespace TaskManager.App.Authorization
{
    public class AuthenticationRequired: Attribute, IActionFilter
    {
        private readonly AuthService _authService = new AuthService();
        private readonly HttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        
        public void OnActionExecuted(ActionExecutedContext context)
        {}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string token = context.HttpContext.Request?.Headers["api_token"];

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedObjectResult("Api token is missing");
                return;
            }

            User? auth = _authService.Authenticate(token);
            
            if (auth == null)
            {
                context.Result = new UnauthorizedObjectResult("Api token provided is not valid");
                return;
            }
            
            var identity = new GenericIdentity(auth.Id.ToString());
            var principal = new GenericPrincipal(identity, null);
            _httpContextAccessor.HttpContext.User = principal;
        }
    }
}