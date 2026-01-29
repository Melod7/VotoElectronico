using Microsoft.AspNetCore.Mvc;
using VotoElectronico.API.Data;
using VotoElectronicoo.API.Models;


namespace VotoElectronico.API.Controllers
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

        [HttpPost]
        public IActionResult Votar(int usuarioId, int candidatoId)
        {
            var usuario = _context.Usuarios.Find(usuarioId);
            if (usuario == null || usuario.YaVoto)
                return BadRequest("Usuario inválido o ya votó");

            var voto = new Voto
            {
                UsuarioId = usuarioId,
                CandidatoId = candidatoId
            };

            usuario.YaVoto = true;

            _context.Votos.Add(voto);
            _context.SaveChanges();

            return Ok("Voto registrado");
        }
    }
}