using Microsoft.AspNetCore.Mvc;
using VotoElectronicoo.API.Data;
using VotoElectronicoo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace VotoElectronicoo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotantesController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public VotantesController(VotoElectronicoContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Votante v)
        {
            _context.Votantes.Add(v);

            var usuario = new Usuario
            {
                Cedula = v.Cedula,
                Nombres = v.Nombres,
                Apellidos = v.Apellidos,
                Correo = v.Correo,
                Contrasena = "1234",
                YaVoto = false,
                RolId = 3
            };

            _context.Usuarios.Add(usuario);

            await _context.SaveChangesAsync();

            return Ok(v);
        }


        [HttpGet]
        public IActionResult GetVotantes()
        {
            var lista = _context.Votantes.ToList();
            return Ok(lista);
        }

       
        [HttpPut("marcar/{cedula}")]
        public IActionResult MarcarVoto(string cedula)
        {
            var votante = _context.Votantes
                .FirstOrDefault(x => x.Cedula == cedula);

            if (votante == null)
                return NotFound();

            votante.YaVoto = true;
            _context.SaveChanges();

            return Ok("Voto registrado");
        }

        [HttpGet("por-cedula/{cedula}")]
        public async Task<IActionResult> ObtenerPorCedula(string cedula)
        {
            var votante = await _context.Votantes
                .FirstOrDefaultAsync(v => v.Cedula == cedula);

            if (votante == null)
                return NotFound();

            return Ok(votante);
        }

        [HttpDelete("{Cedula}")]
        public async Task<IActionResult> Eliminar(string Cedula)
        {
            var votante = await _context.Votantes
                .FirstOrDefaultAsync(v => v.Cedula == Cedula);

            if (votante == null)
                return NotFound();

            _context.Votantes.Remove(votante);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}