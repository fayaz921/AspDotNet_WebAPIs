using AspDotNetCore_WebAPIs.Dtos.Authentication;
using AspDotNetCore_WebAPIs.Dtos.Users;
using AspDotNetCore_WebAPIs.Extentions.Mappers;
using AspDotNetCore_WebAPIs.Repositories.Interfaces;
using AspDotNetCore_WebAPIs.Services.Interfaces;
using AspDotNetCore_WebAPIs.Shared;

namespace AspDotNetCore_WebAPIs.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;
        public UserService(IUserRepo _userrepo)
        {
            userRepo = _userrepo;
        }
        public async Task<GetUserDto> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            var user = userRegisterDto.Map();
            PasswordEncryptor.CreatePasswordHashandSalt(userRegisterDto.Password, out byte[] hash, out byte[] salt);
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            if (user == null) 
            {
                return null!;
            }
            await userRepo.RegisterAsync(user);
            return user.Map();
        }
    }
}
