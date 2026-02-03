using global::VotoElectronico.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotoElectronicoo.API.DTOs;

namespace VotoElectronico.API.Controllers
{
    [ApiController]
    [Route("api/bitacora")]
    public class BitacoraController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public BitacoraController(VotoElectronicoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var logs = await _context.Bitacoras
                .OrderByDescending(b => b.Fecha)
                .Select(b => new BitacoraDTO
                {
                    Fecha = b.Fecha,
                    Rol = b.Rol,
                    Accion = b.Accion,
                    Descripcion = b.Descripcion,
                    Ip = b.Ip
                })
                .ToListAsync();

            return Ok(logs);
        }
    }
}