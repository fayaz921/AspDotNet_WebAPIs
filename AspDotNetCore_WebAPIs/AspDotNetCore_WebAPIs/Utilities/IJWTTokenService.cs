using AspDotNetCore_WebAPIs.Data.Entities;

namespace AspDotNetCore_WebAPIs.Utilities
{
    public interface IJWTTokenService
    {
        Task<string> CreateToken(User user);
    }
}
