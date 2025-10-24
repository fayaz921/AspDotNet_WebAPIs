using AspDotNetCore_WebAPIs.APIResponse;
using AspDotNetCore_WebAPIs.Dtos.Authentication;
using AspDotNetCore_WebAPIs.Dtos.Users;
using AspDotNetCore_WebAPIs.Extentions.Mappers;
using AspDotNetCore_WebAPIs.Repositories.Interfaces;
using AspDotNetCore_WebAPIs.Services.Interfaces;
using AspDotNetCore_WebAPIs.Shared;
using AspDotNetCore_WebAPIs.Utilities;

namespace AspDotNetCore_WebAPIs.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepo authenticationRepo;
        private readonly IJWTTokenService jWTTokenService;
        private readonly IPasswordEncryptor passwordEncryptor;
        public AuthenticationService(IAuthenticationRepo repo, IJWTTokenService jWTToken, IPasswordEncryptor _passwordEncryptor)
        {
            authenticationRepo = repo;
            jWTTokenService = jWTToken;
            passwordEncryptor = _passwordEncryptor;
        }

        public async Task<APIResponses<string>> LoginAsync(UserLoginDto userLogin)
        {
            var user = userLogin.Map();
            var isexists =await authenticationRepo.LoginAsync(user);
            if(isexists is null)
            {
                return APIResponses<string>.FailureResponse("Invalid login credentials");
            }
            if(!passwordEncryptor.VerifyPasswordhashandsalt(userLogin.Password,isexists.PasswordHash,isexists.PasswordSalt))
            {
                return APIResponses<string>.FailureResponse("Invalid login creadentials");
            }

            return APIResponses<string>.SuccessResponse(await jWTTokenService.CreateToken(isexists));    
        }

        public async Task<APIResponses<GetUserDto>> RegisterAsync(UserRegisterDto userRegister)
        {
            //Map from dto to user
            var user = userRegister.Map(passwordEncryptor);

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
