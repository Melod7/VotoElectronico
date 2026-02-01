using Microsoft.AspNetCore.Mvc;
using VotoElectronico.MVC.Data;
using VotoElectronico.MVC.Models;

namespace VotoElectronico.MVC.Controllers
{
    public class VotacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VotacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Partidos.ToList());
        }

        [HttpPost]
        public IActionResult Votar(int partidoId)
        {
            var cedula = HttpContext.Session.GetString("Cedula");
            var votante = _context.Votantes.First(v => v.Cedula == cedula);

            _context.Votos.Add(new Voto
            {
                PartidoId = partidoId,
                Fecha = DateTime.Now
            });

            votante.YaVoto = true;
            _context.SaveChanges();

            return View("Confirmacion");
        }
    }
}