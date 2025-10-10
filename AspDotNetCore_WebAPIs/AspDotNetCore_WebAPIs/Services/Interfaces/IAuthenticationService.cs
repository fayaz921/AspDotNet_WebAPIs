using AspDotNetCore_WebAPIs.APIResponse;
using AspDotNetCore_WebAPIs.Data.Entities;
using AspDotNetCore_WebAPIs.Dtos.Authentication;
using AspDotNetCore_WebAPIs.Dtos.Users;

namespace AspDotNetCore_WebAPIs.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<APIResponses<GetUserDto>> RegisterAsync(UserRegisterDto userRegister);
      
    }
}
