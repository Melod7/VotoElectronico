using Microsoft.AspNetCore.Mvc;

namespace VotoElectronico.MVC.Controllers
{
    public class VotanteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidarCodigo()
        {
            return RedirectToAction("Index", "Votacion");
        }
    }
}