using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotoElectronicoo.API.Data;
using VotoElectronicoo.API.Models;

namespace VotoElectronicoo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotacionController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public VotacionController(VotoElectronicoContext context)
        {
            _context = context;
        }

        // VALIDAR CODIGO (solo comprobar)
        [HttpPost("validar-codigo")]
        public async Task<IActionResult> ValidarCodigo([FromBody] CodigoValidacionDTO dto)
        {
            var codigo = await _context.CodigoVotacion
                .FirstOrDefaultAsync(x =>
                    x.Codigo == dto.Codigo &&
                    x.Cedula == dto.Cedula);

            if (codigo == null)
                return BadRequest("Código inválido");

            if (codigo.Usado)
                return BadRequest("Código ya utilizado");

            // NO marcar usado aquí
            return Ok();
        }
    }

}