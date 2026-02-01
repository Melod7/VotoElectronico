using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace VotoElectronico.MVC.Controllers
{
    public class VotosController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public VotosController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Votar(int candidatoId)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
                return RedirectToAction("Login", "Auth");

            var client = _clientFactory.CreateClient("Api");

            await client.PostAsync(
                $"votos?usuarioId={usuarioId}&candidatoId={candidatoId}",
                null
            );

            return View("Gracias");
        }
    }
}