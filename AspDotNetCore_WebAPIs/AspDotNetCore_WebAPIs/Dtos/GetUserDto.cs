namespace AspDotNetCore_WebAPIs.Dtos
{
    public record GetUserDto(Guid UserId,string FirstName, string LastName, string Email, string Role, string ImageUrl, string Contact);
    
}
