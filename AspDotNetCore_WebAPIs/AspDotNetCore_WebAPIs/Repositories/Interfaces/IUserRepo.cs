using AspDotNetCore_WebAPIs.Data.Entities;

namespace AspDotNetCore_WebAPIs.Repositories.Interfaces
{
    public interface IUserRepo
    {
        Task<User> RegisterAsync(User user);
    }
}
