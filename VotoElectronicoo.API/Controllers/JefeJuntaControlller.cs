using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using VotoElectronicoo.API.Data;
using VotoElectronicoo.API.Models;
using System.Linq;

namespace VotoElectronicoo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JefeJuntaController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public JefeJuntaController(VotoElectronicoContext context)
        {
            _context = context;
        }

        // LOGIN JEFE JUNTA
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginAdminDTO dto)
        {
            try
            {
                var jefe = _context.JefeJunta
                    .FirstOrDefault(x => x.Correo == dto.Correo && x.Clave == dto.Password);

                if (jefe == null)
                    return Unauthorized("Credenciales incorrectas");

                return Ok(jefe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // VALIDAR CEDULA VOTANTE
        [HttpGet("validar/{cedula}")]
        public IActionResult ValidarCedula(string cedula)
        {
            var votante = _context.Votantes.FirstOrDefault(v => v.Cedula == cedula);

            if (votante == null)
                return NotFound("Votante no existe");

            if (votante.YaVoto)
                return BadRequest("Este votante ya votó");

            return Ok(votante);
        }

        // GENERAR CODIGO
        [HttpPost("generar")]
        public async Task<IActionResult> GenerarCodigo([FromBody] JsonElement data)
        {
            try
            {
                var cedula = data.GetString();

                if (string.IsNullOrEmpty(cedula))
                    return BadRequest("Cédula inválida");

                // generar código alfanumérico de 6 caracteres
                var random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

                var codigo = new string(Enumerable.Repeat(chars, 6)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                var nuevoCodigo = new CodigoVotacion
                {
                    Cedula = cedula,
                    Codigo = codigo,
                    Usado = false,
                    Fecha = DateTime.UtcNow 
                };

                _context.CodigoVotacion.Add(nuevoCodigo);
                await _context.SaveChangesAsync();

                return Ok(codigo);
            }
            catch (Exception ex)
            {
                return BadRequest("Error generando código: " + ex.Message);
            }
        }
    }
}