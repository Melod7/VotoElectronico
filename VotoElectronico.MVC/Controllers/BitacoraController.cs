using Microsoft.AspNetCore.Mvc;

namespace VotoElectronico.MVC.Controllers
{
    public class BitacoraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}