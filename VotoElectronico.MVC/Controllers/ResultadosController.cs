using Microsoft.AspNetCore.Mvc;
using VotoElectronico.MVC.Models;
using System.Net.Http.Json;

namespace VotoElectronico.MVC.Controllers
{
    public class ResultadosController : Controller
    {
        private readonly HttpClient _http;

        public ResultadosController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        public async Task<IActionResult> Index()
        {
            var resultados = await _http.GetFromJsonAsync<List<ResultadoDTO>>("api/resultados");

            return View(resultados);
        }
    }
}