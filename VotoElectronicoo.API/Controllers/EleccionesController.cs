using Microsoft.AspNetCore.Mvc;
using VotoElectronicoo.API.Data;
using VotoElectronicoo.API.Models;
using VotoElectronicoo.API.DTOs;


namespace VotoElectronicoo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EleccionesController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public EleccionesController(VotoElectronicoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Elecciones.ToList());
        }

        [HttpPost]
        public IActionResult Create(Eleccion eleccion)
        {
            _context.Elecciones.Add(eleccion);
            _context.SaveChanges();
            return Ok(eleccion);
        }
    }
}