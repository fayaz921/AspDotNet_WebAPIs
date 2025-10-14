using AspDotNetCore_WebAPIs.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspDotNetCore_WebAPIs.Utilities
{
    public class JWTTokenService : IJWTTokenService
    {
        private readonly IConfiguration _configuration;
        public JWTTokenService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public async Task<string> CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role,user.Role),
            };

            var tokenkey =  _configuration.GetSection("Token").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenkey!)); //! null-forgiving operator
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
            var issuer = _configuration.GetSection("IssuerKey").Value;
            var audience = _configuration.GetSection("AudienceKey").Value;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
