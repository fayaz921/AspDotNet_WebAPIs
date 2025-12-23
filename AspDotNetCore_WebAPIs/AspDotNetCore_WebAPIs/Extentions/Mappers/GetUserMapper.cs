using AspDotNetCore_WebAPIs.Data.Entities;
using AspDotNetCore_WebAPIs.Dtos.Users;

namespace AspDotNetCore_WebAPIs.Extentions.Mappers
{
    public static class GetUserMapper
    {
        public static GetUserDto Map(this User user)
        {
            return new GetUserDto(user.UserId,user.FirstName,user.LastName,user.Email,user.Contact,user.Role.ToString(),user.ImageUrl!,user.UserName);
        }

        public static List<GetUserDto> Map(this List<User> users)
        {
            return users.Select(users=> new GetUserDto
            (
                users.UserId,
                users.FirstName,
                users.LastName,
                users.Email,
                users.Contact,
                users.Role.ToString(),
                users.ImageUrl!,
                users.UserName
                ))
                .ToList();
        }
    }
}
