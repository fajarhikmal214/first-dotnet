using Microsoft.AspNetCore.Mvc;
using HelloWorld.Services;
using HelloWorld.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(TokenService tokenService): ControllerBase
    {
        private readonly TokenService _tokenService = tokenService;

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            if (login.Username == "admin" && login.Password == "password")
            {
                var token = _tokenService.CreateToken(login.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}