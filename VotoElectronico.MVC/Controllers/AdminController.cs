using Microsoft.AspNetCore.Mvc;
using VotoElectronico.MVC.Data;
using VotoElectronico.MVC.ViewModels;

namespace VotoElectronico.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View(new AdminLoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(AdminLoginViewModel model)
        {
            var admin = _context.Administradores
                .FirstOrDefault(a => a.Correo == model.Correo && a.Password == model.Password);

            if (admin == null)
            {
                model.MensajeError = "Credenciales inválidas";
                return View(model);
            }

            HttpContext.Session.SetString("Admin", admin.Correo);
            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Admin") == null)
                return RedirectToAction("Login");

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}