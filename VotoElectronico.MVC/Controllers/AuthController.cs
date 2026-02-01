using Microsoft.AspNetCore.Mvc;
using VotoElectronico.MVC.Data;
using VotoElectronico.MVC.ViewModels;

namespace VotoElectronico.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Votante()
        {
            return View(new VotanteLoginViewModel());
        }

        [HttpPost]
        public IActionResult GenerarCodigo(VotanteLoginViewModel model)
        {
            var votante = _context.Votantes.FirstOrDefault(v => v.Cedula == model.Cedula);

            if (votante == null)
            {
                model.MensajeError = "La cédula no consta en el padrón.";
                return View("Votante", model);
            }

            if (votante.YaVoto)
            {
                model.MensajeError = "Usted ya ha votado.";
                return View("Votante", model);
            }

            model.CodigoGenerado = GenerarCodigoRandom();

            HttpContext.Session.SetString("Codigo", model.CodigoGenerado);
            HttpContext.Session.SetString("Cedula", model.Cedula);

            return View("Votante", model);
        }

        [HttpPost]
        public IActionResult ValidarCodigo(VotanteLoginViewModel model)
        {
            var codigo = HttpContext.Session.GetString("Codigo");

            if (codigo != model.CodigoIngresado)
            {
                model.MensajeError = "Código incorrecto.";
                return View("Votante", model);
            }

            return RedirectToAction("Index", "Votacion");
        }

        private string GenerarCodigoRandom()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}