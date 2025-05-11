using ConsultorioOPI.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

/// <summary>
/// Controlador para solicitar el token de de seguirar para cosumin los servicios
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;

    /// <summary>
    /// Constructor del controlador
    /// </summary>
    /// <param name="config"></param>
    public AuthController(IConfiguration config)
    {
        _config = config;
    }

    /// <summary>
    /// Genera un token pidiendo usuario y contraseña
    /// </summary>
    /// <param name="loginData"></param>
    /// <returns>Token</returns>
    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginDataDto loginData)
    {
        // Usuario y clave fijos solo para no hacer un esquema de DB con usuarios y pw
        //si alcanzo implemento el esquema de tabla usuario
        if (loginData.User == "admin" && loginData.Password == "1234")
        {
            var token = GenerateJwtToken();
            return Ok(new { token });
        }
        return Unauthorized();
    }

    /// <summary>
    /// Genera un token sin pedir usuario y contraseña
    /// </summary>
    /// <param name="loginData"></param>
    /// <returns>token</returns>
    [HttpPost("login-without-user")]
    [AllowAnonymous]
    public IActionResult LoginWithoutUser()
    {
        var token = GenerateJwtToken();
        return Ok(new { token });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string GenerateJwtToken()
    {
        var jwtSettings = _config.GetSection("JwtSettings");

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "admin"),
            new Claim(ClaimTypes.Role, "Administrador")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiresInMinutes"]!)),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

