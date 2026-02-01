using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using VotoElectronico.MVC.Models;

namespace VotoElectronico.MVC.Controllers
{
    public class EleccionesController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public EleccionesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("Api");
            var elecciones = await client.GetFromJsonAsync<List<Eleccion>>("elecciones");
            return View(elecciones);
        }
    }
}