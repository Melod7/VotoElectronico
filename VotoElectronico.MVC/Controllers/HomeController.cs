using Microsoft.AspNetCore.Mvc;

namespace VotoElectronico.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ingresar()
        {
            return View();
        }
    }
}