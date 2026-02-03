using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using VotoElectronico.MVC.Models.ViewModels;
using VotoElectronico.MVC.ViewModels;

namespace VotoElectronico.MVC.Controllers
{
    public class BitacoraController : Controller
    {
        private readonly HttpClient _http;

        public BitacoraController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("api");
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Rol") != "Admin")
            {
                return RedirectToAction("Administrador", "Auth");
            }

            var logs = await _http.GetFromJsonAsync<List<BitacoraVM>>("api/bitacora");
            return View(logs ?? new List<BitacoraVM>());
        }
    }
}