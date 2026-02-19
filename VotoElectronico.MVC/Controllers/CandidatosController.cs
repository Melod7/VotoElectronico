using Microsoft.AspNetCore.Mvc;

namespace VotoElectronico.MVC.Controllers
{
    public class CandidatosController : Controller
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