using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotoElectronico.API.Helpers;
using VotoElectronicoo.API.Data;
using VotoElectronicoo.API.DTOs.Auth;
using VotoElectronicoo.API.DTOs.Votos;
using VotoElectronicoo.API.Helpers;
using VotoElectronicoo.API.Models;

namespace VotoElectronicoo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotosController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public VotosController(VotoElectronicoContext context)
        {
            _context = context;
        }

        // ==============================
        // VALIDAR CÓDIGO PARA VOTAR
        // ==============================
        [HttpPost("validar")]
        public async Task<IActionResult> ValidarCodigo([FromBody] LoginCodigoDTO dto)
        {
            var votante = await _context.Votantes
                .FirstOrDefaultAsync(v => v.Cedula == dto.Cedula);

            if (votante == null)
                return BadRequest("No existe votante");

            if (votante.YaVoto)
                return BadRequest("Ya votó");

            var codigo = await _context.CodigoVotacion
                .FirstOrDefaultAsync(c => c.Cedula == dto.Cedula && c.Codigo == dto.Codigo);

            if (codigo == null)
                return BadRequest("Código incorrecto");

            if (codigo.Usado)
                return BadRequest("Código ya utilizado");

            codigo.Usado = true;

            await _context.SaveChangesAsync();

            return Ok();
        }


        // ==============================
        // GENERAR CÓDIGO (JEFE JUNTA)
        // ==============================
        [HttpGet("generar-codigo/{cedula}")]
        public async Task<IActionResult> GenerarCodigo(string cedula)
        {
            var votante = await _context.Votantes
                .FirstOrDefaultAsync(v => v.Cedula == cedula);

            if (votante == null)
                return NotFound("Votante no encontrado");

            if (votante.YaVoto)
                return BadRequest("El votante ya votó");

            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var codigo = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var codigoVotacion = new CodigoVotacion
            {
                Cedula = cedula,
                Codigo = codigo,
                Usado = false,
                Fecha = DateTime.UtcNow
            };

            _context.CodigoVotacion.Add(codigoVotacion);
            await _context.SaveChangesAsync();

            return Ok(codigo);
        }

        // ==============================
        // REGISTRAR VOTO
        // ==============================
        [HttpPost("votar")]
        public async Task<IActionResult> Votar([FromBody] VotoDTO dto)
        {
            // 1. Buscar votante
            var votante = await _context.Votantes
                .FirstOrDefaultAsync(v => v.Cedula == dto.Cedula);

            if (votante == null)
                return BadRequest("No existe votante");

            if (votante.YaVoto)
                return BadRequest("El votante ya sufragó");

            // 2. Buscar usuario (OBLIGATORIO por la FK)
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Cedula == dto.Cedula);

            if (usuario == null)
                return BadRequest("No existe usuario asociado al votante");

            // 3. Obtener elección activa
            var eleccion = await _context.Elecciones
                .FirstOrDefaultAsync(e => e.Activa);

            if (eleccion == null)
                return BadRequest("No hay elecciones activas");

            // 4. Crear voto
            var voto = new Voto
            {
                UsuarioId = usuario.Id,
                VotanteId = votante.Id,
                EleccionId = eleccion.Id,
                CandidatoId = dto.CandidatoId,
                Fecha = DateTime.UtcNow
            };

            _context.Votos.Add(voto);

            // 5. marcar como que ya votó
            votante.YaVoto = true;

            await _context.SaveChangesAsync();

            // 6. bitácora
            var bit = new Bitacora
            {
                Cedula = votante.Cedula,
                Rol = "Votante",
                Accion = "Votó correctamente",
                Fecha = DateTime.UtcNow,
                Mesa = votante.Mesa,
                Recinto = votante.Recinto
            };

            _context.Bitacoras.Add(bit);
            await _context.SaveChangesAsync();

            // 7. certificado
            var pdfBytes = PdfHelper.GenerarCertificado(
                votante.Nombres,
                votante.Apellidos,
                votante.Cedula
            );

            // 8. correo
            if (!string.IsNullOrEmpty(votante.Correo))
            {
               EmailHelper.Enviar(
                    votante.Correo,
                    "Certificado de votación",
                    "Adjunto su certificado de votación",
                    pdfBytes
                );
            }

            return Ok("Voto registrado correctamente");
        }
    }
    public class LoginCodigoDTO
    {
        public string Cedula { get; set; } = "";
        public string Codigo { get; set; } = "";
    }

    // DTO VOTAR
    public class VotoDTO
    {
        public string Cedula { get; set; } = "";
        public string Codigo { get; set; } = "";
        public int CandidatoId
        {
            get; set;

        }
    }
}