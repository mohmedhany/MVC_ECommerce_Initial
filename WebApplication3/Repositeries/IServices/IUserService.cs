using Microsoft.AspNetCore.Identity;

namespace WebApplication3.Repositeries.IServices
{
    public interface IUserService
    {
        Task<string> GetCurrentUserIdAsync();
        Task<IdentityUser> GetCurrentUserAsync();


    }
}
