using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace VotoElectronico.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _http;

        public AuthController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        // ================================
        // LOGIN ADMIN
        // ================================
        public IActionResult LoginAdmin()
        {
            return View();
        }

        // LOGIN ADMIN POST  
        [HttpPost]
        public async Task<IActionResult> LoginAdmin(string correo, string password)
        {
            var datos = new
            {
                correo = correo,
                password = password
            };

            var json = new StringContent(
                JsonSerializer.Serialize(datos),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.PostAsync("api/Auth/login-admin", json);

            if (response.IsSuccessStatusCode)
            {
                // login correcto → ir panel admin  
                return RedirectToAction("PanelAdmin", "Admin");
            }

            ViewBag.Error = "Correo o contraseña incorrectos";
            return View();
        }



        // ================================
        // LOGIN JEFE JUNTA
        // ================================

       
        public IActionResult LoginJefe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginJefe(string correo, string clave)
        {
            var datos = new
            {
                correo = correo,
                password = clave
            };

            var json = new StringContent(
                JsonSerializer.Serialize(datos),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.PostAsync("api/JefeJunta/login", json);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Panel", "JefeJunta");
            }

            ViewBag.Error = "Credenciales incorrectas";
            return View();
        }




        // ================================
        // LOGIN VOTANTE (con código)
        // ================================

        public IActionResult LoginVotante()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginVotante(string cedula, string codigo)
        {
            var datos = new
            {
                cedula = cedula,
                codigo = codigo
            };

            var json = new StringContent(
                JsonSerializer.Serialize(datos),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.PostAsync("api/Votos/validar", json);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Candidatos", "Votacion");
            }

            ViewBag.Error = "Código incorrecto o ya votó";
            return View();
        }
    }
}