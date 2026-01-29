using Microsoft.AspNetCore.Mvc;
using VotoElectronico.API.Data;
using VotoElectronicoo.API.Models;

namespace VotoElectronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public CandidatosController(VotoElectronicoContext context)
        {
            _context = context;
        }

        [HttpGet("{eleccionId}")]
        public IActionResult GetByEleccion(int eleccionId)
        {
            return Ok(_context.Candidatos
                .Where(c => c.EleccionId == eleccionId)
                .ToList());
        }

        [HttpPost]
        public IActionResult Create(Candidato candidato)
        {
            _context.Candidatos.Add(candidato);
            _context.SaveChanges();
            return Ok(candidato);
        }
    }
}