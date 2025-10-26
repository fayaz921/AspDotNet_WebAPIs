using AspDotNetCore_WebAPIs.Dtos.Authentication;
using AspDotNetCore_WebAPIs.Filters;
using AspDotNetCore_WebAPIs.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCore_WebAPIs.Controllers
{
    /// <summary>
    ///  Controller responsible for handling user authentication-related operations such as registration and login.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ValidateModelState]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="_authenticationService">The authentication service used to handle authentication operations.</param>
        /// <param name="_logger">The logger used to log information, warnings, and errors related to authentication processes.</param>
        public AuthenticationController(IAuthenticationService _authenticationService, ILogger<AuthenticationController> _logger)
        {
            authenticationService = _authenticationService;
            logger = _logger;
        }

        /// <summary>
        /// Registers a new user with the provided registration details.
        /// </summary>
        /// <remarks>This method logs the start of the user registration process and delegates the
        /// registration logic to the authentication service.</remarks>
        /// <param name="userRegisterDto">The data transfer object containing user registration details.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the registration operation. Returns <see
        /// cref="OkObjectResult"/> with the registration response if successful; otherwise, returns <see
        /// cref="ConflictObjectResult"/> if registration fails.</returns>
        /// <response code="200">User registered successfully.</response>
        /// <response code="409">Registration failed (duplicate or invalid data).</response>

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            logger.LogInformation("User Registration start");
            var response = await authenticationService.RegisterAsync(userRegisterDto);
            if (response == null)
            {
                return Conflict("Registration failed");
            }
            return Ok(response);
        }
        /// <summary>
        /// Authenticates a user based on the provided login credentials.
        /// </summary>
        /// <param name="userLoginDto">The data transfer object containing the user's login credentials.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the login attempt. Returns <see
        /// cref="NotFoundResult"/> if the login fails, or <see cref="OkObjectResult"/> with the authentication response
        /// if successful.</returns>
        /// <response code="200">Login successful.</response>
        /// <response code="404">Invalid credentials or user not found.</response>



        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var response = await authenticationService.LoginAsync(userLoginDto);
            return response.Data is null ? NotFound(response) : Ok(response);
        }
    }
}
