using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VotoElectronico.MVC.Models;

namespace VotoElectronico.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly HttpClient _http;

        public AdminController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient();
            _http.BaseAddress = new Uri("https://localhost:7126/");
        }

        // PANEL
        public IActionResult PanelAdmin()
        {
            return View();
        }

        // ===============================
        // CANDIDATOS
        // ===============================
        public async Task<IActionResult> Candidatos()
        {
            try
            {
                var response = await _http.GetAsync("api/Candidatos");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Error = "No se pudo conectar con API";
                    return View(new List<Candidato>());
                }

                var data = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<List<Candidato>>(data);

                return View(lista);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<Candidato>());
            }
        }

        // ===============================
        // VOTANTES
        // ===============================
        public async Task<IActionResult> Votantes()
        {
            var lista = await _http.GetFromJsonAsync<List<Votante>>("api/votantes");
            return View(lista);
        }

        public async Task<IActionResult> EliminarVotante(string Cedula)
        {
            await _http.DeleteAsync($"api/votantes/{Cedula}");
            return RedirectToAction("Votantes");
        }
        // ===============================
        // BITACORA
        // ===============================
        public async Task<IActionResult> Bitacora()
        {
            var lista = await _http.GetFromJsonAsync<List<Bitacora>>("api/bitacora");
            return View(lista);
        }

        // ===============================
        // CREAR VOTANTE (GET)
        // ===============================
        public IActionResult CrearVotante()
        {
            return View();
        }

        // ===============================
        // CREAR VOTANTE (POST)
        // ===============================
        [HttpPost]
        public async Task<IActionResult> CrearVotante(Votante votante)
        {
            votante.YaVoto = false;

            var response = await _http.PostAsJsonAsync("api/votantes", votante);

            return RedirectToAction("Votantes");
        
        }

        public async Task<IActionResult> Resultados()
        {
            var resultados = await _http.GetFromJsonAsync<List<ResultadoVM>>("api/resultados");
            return View(resultados);
        }
    }
}