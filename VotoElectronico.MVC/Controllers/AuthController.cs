using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotoElectronico.MVC.Data;
using VotoElectronico.MVC.Models;

namespace VotoElectronico.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LOGIN ADMINISTRADOR
        [HttpGet]
        public IActionResult Administrador()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Administrador(string usuario, string clave)
        {
            var admin = _context.Administradores
                .FirstOrDefault(a => a.Usuario == usuario && a.Clave == clave);

            if (admin == null)
            {
                ViewBag.Error = "Credenciales incorrectas";
                return View();
            }

            HttpContext.Session.SetString("Rol", "Administrador");
            HttpContext.Session.SetInt32("AdminId", admin.Id);

            return RedirectToAction("Index", "Admin");
        }

        // LOGIN JEFE DE JUNTA
        
        [HttpGet]
        public IActionResult JefeJunta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JefeJunta(string cedula)
        {
            var jefe = _context.JefesJunta.FirstOrDefault(j => j.Cedula == cedula);

            if (jefe == null)
            {
                ViewBag.Error = "Cédula no registrada como Jefe de Junta";
                return View();
            }

            jefe.CodigoAcceso = GenerarCodigo();
            jefe.CodigoExpira = DateTime.Now.AddMinutes(10);

            _context.SaveChanges();

            ViewBag.Codigo = jefe.CodigoAcceso;
            ViewBag.Mesa = jefe.Mesa;

            return View("CodigoJefeJunta");
        }

        // INGRESO VOTANTE
        [HttpGet]
        public IActionResult Votante()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerarCodigo(string cedula)
        {
            var votante = _context.Votantes.FirstOrDefault(v => v.Cedula == cedula);

            if (votante == null)
            {
                ViewBag.Error = "La cédula no existe en el padrón.";
                return View("JefeJunta");
            }

            if (votante.YaVoto)
            {
                ViewBag.Error = "Este votante ya sufragó.";
                return View("JefeJunta");
            }

            var codigo = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

            votante.CodigoVotacion = codigo;
            votante.CodigoExpira = DateTime.Now.AddMinutes(10);

            _context.SaveChanges();

            ViewBag.Codigo = codigo;
            return View("JefeJunta");
        }
        [HttpPost]
        public IActionResult ValidarVotante(string cedula, string codigo)
        {
            var votante = _context.Votantes.FirstOrDefault(v =>
                v.Cedula == cedula &&
                v.CodigoVotacion == codigo
            );

            if (votante == null)
            {
                ViewBag.Error = "Cédula o código incorrectos.";
                return View("Votante");
            }

            if (votante.YaVoto)
            {
                ViewBag.Error = "Este votante ya sufragó.";
                return View("Votante");
            }

            if (votante.CodigoExpira == null || votante.CodigoExpira < DateTime.Now)
            {
                ViewBag.Error = "El código ha expirado.";
                return View("Votante");
            }

            // Guardar sesión
            HttpContext.Session.SetString("Cedula", votante.Cedula);
            HttpContext.Session.SetInt32("VotanteId", votante.Id);

            return RedirectToAction("Index", "Votacion");
        }

        [HttpPost]
        public IActionResult IngresarVotar(string cedula, string codigo)
        {
            var votante = _context.Votantes.FirstOrDefault(v =>
                v.Cedula == cedula &&
                v.CodigoVotacion == codigo &&
                v.CodigoExpira > DateTime.Now);

            if (votante == null)
            {
                TempData["Error"] = "Código incorrecto o expirado";
                return RedirectToAction("Votante");
            }

            HttpContext.Session.SetString("Rol", "Votante");
            HttpContext.Session.SetInt32("VotanteId", votante.Id);

            return RedirectToAction("Index", "Votacion");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        private string GenerarCodigo()
        {
            return Guid.NewGuid()
                .ToString("N")
                .Substring(0, 6)
                .ToUpper();
        }
    }
}