using Inforce.Interfaces;
using Inforce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Inforce.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        public AuthController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                await _authService.Register(request);
            }
             catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.Login(request);
            
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _config["AuthOptions:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", result.Id.ToString()),
                        new Claim("Login", result.Login),
                    };

            var jwt = new JwtSecurityToken(
                   _config["AuthOptions:ISSUER"],
                        _config["AuthOptions:AUDIENCE"],
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(15)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            LoginResponse loginResponse = new LoginResponse { 
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                Role = result.Role.Name,
                Login = result.Login};

            return loginResponse;
        }
    }
}
