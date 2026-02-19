using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotoElectronico.MVC.Models;
using VotoElectronicoo.API.Data;
using VotoElectronicoo.API.Models;

namespace VotoElectronicoo.API.Controllers
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
        [HttpGet]
        public async Task<IActionResult> ObtenerResultados()
        {
            // Total general de votos
            var totalVotos = await _context.Votos.CountAsync();

            // Resultados por candidato
            var resultados = await _context.Candidatos
                .Select(c => new ResultadoDTO
                {
                    NombreCandidato = c.NombrePresidente,
                    Partido = c.Partido,
                    TotalVotos = _context.Votos.Count(v => v.CandidatoId == c.Id),
                    Porcentaje = totalVotos == 0 ? 0 :
                        (_context.Votos.Count(v => v.CandidatoId == c.Id) * 100.0) / totalVotos
                })
                .ToListAsync();

            return Ok(resultados);
        }
    }
}