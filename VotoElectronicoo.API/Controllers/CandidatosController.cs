using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotoElectronicoo.API.Data;
using VotoElectronicoo.API.Models;

namespace VotoElectronicoo.API.Controllers
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _context.Candidatos.ToListAsync();
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Candidato c)
        {
            _context.Candidatos.Add(c);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}