using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using VotoElectronico.MVC.Models;

namespace VotoElectronico.MVC.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CandidatosController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index(int eleccionId)
        {
            var client = _clientFactory.CreateClient("Api");
            var candidatos = await client.GetFromJsonAsync<List<Candidato>>(
                $"candidatos/{eleccionId}"
            );

            ViewBag.EleccionId = eleccionId;
            return View(candidatos);
        }
    }
}