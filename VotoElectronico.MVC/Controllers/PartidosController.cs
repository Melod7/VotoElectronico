using Microsoft.AspNetCore.Mvc;
using VotoElectronico.MVC.Data;
using VotoElectronico.MVC.Models;

namespace VotoElectronico.MVC.Controllers
{
    public class PartidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Partidos.ToList());
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Partido partido)
        {
            _context.Partidos.Add(partido);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}