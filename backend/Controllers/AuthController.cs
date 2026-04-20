using Microsoft.AspNetCore.Mvc;
using PromartStore.API.Data;
using PromartStore.API.DTOs;
using PromartStore.API.Services;

namespace PromartStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AppDbContext db, ITokenService tokenService) : ControllerBase
{
    /// <summary>
    /// Autentica al usuario y retorna un token JWT.
    /// </summary>
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = db.Users.FirstOrDefault(u => u.Username == request.Username);

        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Unauthorized(new { message = "Credenciales incorrectas." });

        var token = tokenService.GenerateToken(user.Username);

        return Ok(new LoginResponseDto(token, user.Username));
    }
}
