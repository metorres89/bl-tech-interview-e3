using Microsoft.AspNetCore.Mvc;
using BlTechInterviewE3.Business.Domain;
using BlTechInterviewE3.Business.Service.Contract;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;

namespace BlTechInterviewE3.WebApi.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] UserLogin userLogin)
    {
        // Validate user credentials using IUserService or any other service
        var user = await _userService.GetByCredentials(userLogin.Email, userLogin.Password);

        if (user != null)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                // Add additional claims as needed
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["APP_JWT_SECRET_KEY"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor {
                Issuer = _configuration["APP_JWT_ISSUER"],
                Audience = _configuration["APP_JWT_AUDIENCE"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["APP_JWT_EXPIRATION_IN_MINUTES"])),
                SigningCredentials = creds
            };

            JsonWebTokenHandler handler = new();

            return Ok(new { token = handler.CreateToken(tokenDescriptor) });
        }

        return Unauthorized();
    }
}
