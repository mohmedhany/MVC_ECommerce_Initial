using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebApplication3.Models;
using WebApplication3.Repositeries.IServices;

namespace WebApplication3.Repositeries.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetCurrentUserIdAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                return null; // Or handle the case where HttpContext is null
            }

            var userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

        public async Task<IdentityUser> GetCurrentUserAsync()
        {
            var userId = await GetCurrentUserIdAsync();
            if (userId != null)
            {
                var user = await _userManager.FindByIdAsync(userId);
                return user;
            }

            return null; // Or handle the case where user is not found
        }
    }
}