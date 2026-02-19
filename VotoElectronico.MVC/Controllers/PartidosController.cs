using Microsoft.AspNetCore.Mvc;

namespace VotoElectronico.MVC.Controllers
{
    public class PartidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }
    }
}