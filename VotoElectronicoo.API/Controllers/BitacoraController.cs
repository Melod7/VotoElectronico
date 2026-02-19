using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotoElectronicoo.API.Data;

namespace VotoElectronicoo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public BitacoraController(VotoElectronicoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBitacora()
        {
            var lista = await _context.Bitacoras
                .OrderByDescending(x => x.Fecha)
                .ToListAsync();

            return Ok(lista);
        }
    }
}