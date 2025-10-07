namespace AspDotNetCore_WebAPIs.Dtos.Users
{
    public record AddUserDto(string FirstName,string LastName,string Email,string Password,string Role,string ImageUrl,string Contact);
}
