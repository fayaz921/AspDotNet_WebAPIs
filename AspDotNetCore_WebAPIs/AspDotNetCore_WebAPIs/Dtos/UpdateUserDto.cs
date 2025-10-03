namespace AspDotNetCore_WebAPIs.Dtos
{
    public record UpdateUserDto(Guid UserId,string FirstName, string LastName, string Role, string ImageUrl, string Contact);
    
    
}
