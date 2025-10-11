using AspDotNetCore_WebAPIs.Data.Entities;
using AspDotNetCore_WebAPIs.Dtos.Authentication;

namespace AspDotNetCore_WebAPIs.Extentions.Mappers
{
    public static class UserLoginMapper
    {
        public static User Map(this UserLoginDto userLoginDto)
        {

            return new User
            {
                UserName = userLoginDto.UserIdentifier,
                Email = userLoginDto.UserIdentifier,
                Contact = userLoginDto.UserIdentifier,
            };
        }
    }
}
