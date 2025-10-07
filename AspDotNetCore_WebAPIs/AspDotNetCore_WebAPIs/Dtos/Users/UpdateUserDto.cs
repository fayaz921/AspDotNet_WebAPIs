namespace AspDotNetCore_WebAPIs.Dtos.Users
{
    public record UpdateUserDto(Guid UserId,string FirstName, string LastName, string Role, string ImageUrl, string Contact);
    
    
}
