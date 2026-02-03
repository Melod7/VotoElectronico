using Microsoft.AspNetCore.Mvc;
using VotoElectronico.MVC.Data;
using VotoElectronico.MVC.ViewModels;


public class ResultadosController : Controller
{
    private readonly ApplicationDbContext _context;

    public ResultadosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Seguridad: solo administrador
        var rol = HttpContext.Session.GetString("Rol");
        if (rol != "Administrador")
            return RedirectToAction("Index", "Auth");

        var totalVotos = _context.Votos.Count();

        var resultados = _context.Candidatos
            .Select(c => new ResultadoViewModel
            {
                Candidato = c.Nombre,
                TotalVotos = _context.Votos.Count(v => v.CandidatoId == c.Id),
                Porcentaje = totalVotos == 0 ? 0 :
                    (double)_context.Votos.Count(v => v.CandidatoId == c.Id) * 100 / totalVotos
            })
            .ToList();

        ViewBag.TotalVotos = totalVotos;

        return View(resultados);
    }
}