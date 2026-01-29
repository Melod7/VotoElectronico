using Microsoft.AspNetCore.Mvc;
using VotoElectronico.API.Data;
using VotoElectronicoo.API.DTOs.Auth;

namespace VotoElectronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public AuthController(VotoElectronicoContext context)
        {
            _context = context;
        }

        [HttpPost("login-codigo")]
        public IActionResult LoginConCodigo(LoginCodigoDTO dto)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Cedula == dto.Cedula);

            if (usuario == null)
                return Unauthorized("Usuario no encontrado");

            return Ok("Login correcto (simulado)");
        }

        [HttpPost("login-admin")]
        public IActionResult LoginAdmin(LoginAdminDTO dto)
        {
            return Ok("Admin logueado (simulado)");
        }
    }
}