using AspDotNetCore_WebAPIs.Data.Entities;
using AspDotNetCore_WebAPIs.Dtos.Users;

namespace AspDotNetCore_WebAPIs.Extentions.Mappers
{
    public static class GetUserMapper
    {
        public static GetUserDto Map(this User user)
        {
            return new GetUserDto(user.UserId,user.FirstName,user.LastName,user.Email,user.Contact,user.Role,user.ImageUrl!);
        }
    }
}
