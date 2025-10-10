namespace AspDotNetCore_WebAPIs.Dtos.Users
{
    public record GetUserDto(Guid UserId,string FirstName, string LastName, string Email, string Role, string ImageUrl, string Contact,string UserName);
    
}
