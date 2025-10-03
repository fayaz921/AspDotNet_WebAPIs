namespace AspDotNetCore_WebAPIs.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();

        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        public string Role { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public string Contact { get; set; } = string.Empty;

        public string? OTP { get; set; }
    }
}
