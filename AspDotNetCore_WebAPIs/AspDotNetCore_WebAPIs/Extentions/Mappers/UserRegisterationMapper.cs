using AspDotNetCore_WebAPIs.Data.Entities;
using AspDotNetCore_WebAPIs.Dtos.Authentication;

namespace AspDotNetCore_WebAPIs.Extentions.Mappers
{
    public static class UserRegisterationMapper
    {
        public static User Map(this UserRegisterDto dto)
        {
            return new User
            {
                UserId = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
      
            };
        }
    }
}
