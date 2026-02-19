using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace VotoElectronico.MVC.Controllers
{
    public class JefeJuntaController : Controller
    {
        private readonly HttpClient _http;

        public JefeJuntaController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        // =========================
        // LOGIN JEFE JUNTA
        // =========================
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string correo, string clave)
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
                return RedirectToAction("Panel");
            }

            ViewBag.Error = "Credenciales incorrectas";
            return View();
        }

        // PANEL JEFE JUNTA
        public IActionResult Panel()
        {
            return View();
        }
        public IActionResult Validar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ValidarCedula(string cedula)
        {
            var response = await _http.GetAsync($"api/JefeJunta/validar/{cedula}");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Votante no encontrado";
                return View("Validar");
            }

            return RedirectToAction("GenerarCodigo", new { cedula = cedula });
        }

        // MOSTRAR VISTA
        public IActionResult GenerarCodigo(string cedula)
        {
            ViewBag.Cedula = cedula;
            return View();
        }
        // POST GENERAR CODIGO
        [HttpPost]
        public async Task<IActionResult> GenerarCodigoPost(string cedula)
        {
            var json = new StringContent(
                JsonSerializer.Serialize(cedula),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.PostAsync("api/JefeJunta/generar", json);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Error generando código";
                return View();
            }

            var codigo = await response.Content.ReadAsStringAsync();

            codigo = codigo.Replace("\"", "");

            return RedirectToAction("CodigoGenerado",
                new { codigo = codigo, cedula = cedula });
        }
        // MOSTRAR CODIGO
        public IActionResult CodigoGenerado(string codigo, string cedula)
        {
            ViewBag.Codigo = codigo;
            ViewBag.Cedula = cedula;
            return View("CodigoGenerado");
        }
    }
}
    
