namespace AspDotNetCore_WebAPIs.Dtos.Users
{
    public record GetUserDto(Guid UserId,string FirstName, string LastName, string Email, string Contact, string ImageUrl, string Role,string UserName);
    
}
