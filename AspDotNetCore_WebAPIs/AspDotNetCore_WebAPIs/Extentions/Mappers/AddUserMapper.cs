using AspDotNetCore_WebAPIs.Data.Entities;
using AspDotNetCore_WebAPIs.Dtos;

namespace AspDotNetCore_WebAPIs.Extentions.Mappers
{
    public static class AddUserMapper
    {
        public static User ToUser(this AddUserDto dto)
        {
            return new User
            {
                UserId = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                ImageUrl = dto.ImageUrl,
                Contact = dto.Contact,
                Role = dto.Role,

            };
        }
    }
}
