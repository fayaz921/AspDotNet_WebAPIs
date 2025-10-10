using AspDotNetCore_WebAPIs.APIResponse;
using AspDotNetCore_WebAPIs.Dtos.Authentication;
using AspDotNetCore_WebAPIs.Dtos.Users;
using AspDotNetCore_WebAPIs.Extentions.Mappers;
using AspDotNetCore_WebAPIs.Repositories.Interfaces;
using AspDotNetCore_WebAPIs.Services.Interfaces;

namespace AspDotNetCore_WebAPIs.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepo authenticationRepo;
        public AuthenticationService(IAuthenticationRepo repo)
        {
            authenticationRepo = repo;
        }
        public async Task<APIResponses<GetUserDto>> RegisterAsync(UserRegisterDto userRegister)
        {
            //Map from dto to user
            var user = userRegister.Map();

            //user check if it exists or not 
            var usercheck = await authenticationRepo.UserCheckAsync(user);
            //if user creadentials is present 
            if (usercheck != null)
            {
                if (usercheck.Email == userRegister.Email)
                {
                    return APIResponses<GetUserDto>.FailureResponse("Email already exists");
                }
                if (usercheck.Contact == userRegister.Contact)
                {
                    return APIResponses<GetUserDto>.FailureResponse("Contact already exists");
                }
                if (usercheck.UserName == userRegister.UserName)
                {
                    return APIResponses<GetUserDto>.FailureResponse("Username already exists");
                }
            }

            //if user is null then register user
            var userentity = await authenticationRepo.RegisterAsync(user);
            return APIResponses<GetUserDto>.SuccessResponse(userentity.Map());
        }
    }
}
