using AspDotNetCore_WebAPIs.Dtos.Authentication;
using AspDotNetCore_WebAPIs.Dtos.Users;

namespace AspDotNetCore_WebAPIs.Services.Interfaces
{
    public interface IUserService
    {
        Task<GetUserDto> RegisterAsync(UserRegisterDto userRegisterDto);
    }
}
