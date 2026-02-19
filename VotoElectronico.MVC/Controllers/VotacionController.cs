using Microsoft.AspNetCore.Mvc;
using VotoElectronico.MVC.Models;
using System.Net.Http.Json;
using System.Text;

namespace VotoElectronico.MVC.Controllers
{
    public class VotacionController : Controller
    {
        private readonly HttpClient _http;

        public VotacionController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        // ============================
        // INGRESO CEDULA + CODIGO
        // ============================
        public IActionResult Ingresar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ingresar(string cedula, string codigo)
        {
            var data = new
            {
                Cedula = cedula,
                Codigo = codigo
            };

            var response = await _http.PostAsJsonAsync("api/Votos/validar", data);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Código inválido, expirado o ya utilizado";
                return View();
            }

            // guardar sesión
            HttpContext.Session.SetString("Cedula", cedula);
            HttpContext.Session.SetString("Codigo", codigo);

            return RedirectToAction("Candidatos");
        }

        
        // LISTA CANDIDATOS
        public async Task<IActionResult> Candidatos()
        {
            var cedula = HttpContext.Session.GetString("Cedula");

            if (string.IsNullOrEmpty(cedula))
                return RedirectToAction("Votante", "Auth");

            var lista = await _http.GetFromJsonAsync<List<Candidato>>("api/candidatos");

            return View(lista);
        }


        [HttpPost]
        public async Task<IActionResult> Votar(int candidatoId)
        {
            var cedula = HttpContext.Session.GetString("Cedula");
            var codigo = HttpContext.Session.GetString("Codigo");

            if (string.IsNullOrEmpty(cedula))
                return RedirectToAction("Ingresar");

            var voto = new
            {
                Cedula = cedula,
                Codigo = codigo,
                CandidatoId = candidatoId
            };

            var response = await _http.PostAsJsonAsync("api/votos/votar", voto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Confirmacion");

            TempData["Error"] = "No se pudo registrar el voto";
            return RedirectToAction("Candidatos");
        
        }
        [HttpPost]
        public IActionResult GuardarDatosVotante(string correo)
        {
            HttpContext.Session.SetString("Correo", correo);

            return RedirectToAction("Candidatos");
        }
        // CONFIRMACION

        public IActionResult Confirmacion()
        {
            return View();
        }

        // YA VOTO
        
        public IActionResult YaVoto()
        {
            return View();
        }
    }
}