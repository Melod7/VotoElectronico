using Microsoft.AspNetCore.Mvc;
using VotoElectronico.API.Data;
using VotoElectronicoo.API.Models;

namespace VotoElectronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultadosController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public ResultadosController(VotoElectronicoContext context)
        {
            _context = context;
        }

        [HttpGet("{eleccionId}")]
        public IActionResult GetResultados(int eleccionId)
        {
            var resultados = _context.Votos
                .Where(v => v.Candidato.EleccionId == eleccionId)
                .GroupBy(v => v.Candidato.Nombre)
                .Select(g => new
                {
                    Candidato = g.Key,
                    Votos = g.Count()
                })
                .ToList();

            return Ok(resultados);
        }
    }
}