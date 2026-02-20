using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using VotoElectronicoo.API.Data;
using VotoElectronicoo.API.DTOs.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace VotoElectronicoo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;
        private readonly IConfiguration _config;

        public AuthController(VotoElectronicoContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // ===============================
        // LOGIN ADMIN
        // ===============================
        [HttpPost("login-admin")]
        public IActionResult LoginAdmin([FromBody] LoginAdminDTO dto)
        {
            var admin = _context.Administradores
                .FirstOrDefault(x => x.Correo == dto.Correo && x.Password == dto.Password);

            if (admin == null)
                return Unauthorized("Correo o contraseña incorrectos");

            // generar token
            var token = GenerarToken(admin.Correo, "Admin");

            return Ok(new
            {
                token = token,
                usuario = admin.Correo,
                rol = "Admin"
            });
        }

        // ===============================
        // LOGIN VOTANTE
        // ===============================
        [HttpPost("login-votante")]
        public IActionResult LoginVotante([FromBody] LoginVotanteDTO dto)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(x => x.Cedula == dto.Cedula && x.Contrasena == dto.Password);

            if (usuario == null)
                return Unauthorized("Credenciales incorrectas");

            var token = GenerarToken(usuario.Cedula, "Votante");

            return Ok(new
            {
                token = token,
                usuario = usuario.Cedula,
                rol = "Votante"
            });
        }

        // ===============================
        // GENERAR TOKEN JWT
        // ===============================
        private string GenerarToken(string usuario, string rol)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario),
                new Claim(ClaimTypes.Role, rol)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(4),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    // ===============================
    // DTO ADMIN
    // ===============================
    public class LoginAdminDTO
    {
        public string Correo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    // ===============================
    // DTO VOTANTE
    // ===============================
    public class LoginVotanteDTO
    {
        public string Cedula { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}