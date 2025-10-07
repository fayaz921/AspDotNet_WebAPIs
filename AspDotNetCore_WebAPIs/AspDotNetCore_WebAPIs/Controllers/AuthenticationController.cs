using AspDotNetCore_WebAPIs.Dtos.Authentication;
using AspDotNetCore_WebAPIs.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCore_WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService userService;
        public AuthenticationController(IUserService _userService)
        {
            userService = _userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var user = await userService.RegisterAsync(userRegisterDto);
            if (user == null)
            {
                return BadRequest("User Email Already Exist.");
            }
            return Ok(user);
        }
    }
}
