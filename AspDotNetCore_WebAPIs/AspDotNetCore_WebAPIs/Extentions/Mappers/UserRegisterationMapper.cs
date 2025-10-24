using AspDotNetCore_WebAPIs.Data.Entities;
using AspDotNetCore_WebAPIs.Dtos.Authentication;
using AspDotNetCore_WebAPIs.Shared;

namespace AspDotNetCore_WebAPIs.Extentions.Mappers
{
    public static class UserRegisterationMapper
    {
        public static User Map(this UserRegisterDto dto,IPasswordEncryptor passwordEncryptor)
        {
            passwordEncryptor.CreatePasswordHashandSalt(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            return new User
            {
                UserId = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Contact = dto.Contact,
                UserName = dto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,

            };
        }
    }
}
