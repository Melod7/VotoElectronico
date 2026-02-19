using Microsoft.AspNetCore.Mvc;
using VotoElectronicoo.API.Data;
using VotoElectronicoo.API.DTOs.Auth;

namespace VotoElectronicoo.API.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public AuthController(VotoElectronicoContext context)
        {
            _context = context;
        }

        // LOGIN ADMIN
        [HttpPost("login-admin")]
        public IActionResult LoginAdmin([FromBody] LoginAdminDTO dto)
        {
            var admin = _context.Administradores
                .FirstOrDefault(x => x.Correo == dto.Correo && x.Password == dto.Password);

            if (admin == null)
                return Unauthorized("Correo o contraseña incorrectos");

            return Ok(admin);
        }
    }

    public class LoginAdminDTO
    {
        public string Correo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    
    }
}