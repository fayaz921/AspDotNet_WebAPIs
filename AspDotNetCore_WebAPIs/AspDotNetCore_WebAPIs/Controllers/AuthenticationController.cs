using AspDotNetCore_WebAPIs.Dtos.Authentication;
using AspDotNetCore_WebAPIs.Filters;
using AspDotNetCore_WebAPIs.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCore_WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ValidateModelState]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ILogger logger;
        public AuthenticationController(IAuthenticationService _authenticationService, ILogger<AuthenticationController> _logger)
        {
            authenticationService = _authenticationService;
            logger = _logger;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            logger.LogInformation("User Registration start");
            var response = await authenticationService.RegisterAsync(userRegisterDto);
            if(response == null)
            {
                return Conflict("Registration failed");
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var response = await authenticationService.LoginAsync(userLoginDto);
            return response.Data is null ? NotFound(response) : Ok(response);
        }
    }
}
