using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PREGUNTAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SessionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login"), AllowAnonymous]
        public IActionResult login()
        {
            SecurityTokenDescriptor desc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, "otros")
                }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration.GetSection("AppSettings:Jwt:Exp_min").Value)),
                Issuer = _configuration.GetSection("AppSettings:Jwt:Issuer").Value,
                Audience = _configuration.GetSection("AppSettings:Jwt:Audience").Value,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Jwt:Key").Value)), SecurityAlgorithms.HmacSha512Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken token = handler.CreateToken(desc);

            return Ok(handler.WriteToken(token));
        }
    }
}
