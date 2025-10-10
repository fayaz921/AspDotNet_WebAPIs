using AspDotNetCore_WebAPIs.Data.Entities;

namespace AspDotNetCore_WebAPIs.Repositories.Interfaces
{
    public interface IAuthenticationRepo
    {
        Task<User> RegisterAsync(User user);
        Task<User> LoginAsync(User user);
    }
}
