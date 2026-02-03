using Microsoft.AspNetCore.Mvc;
using VotoElectronico.MVC.Data;
using VotoElectronico.MVC.Models;

public class JefeJuntaController : Controller
{
    private readonly ApplicationDbContext _context;
    public JefeJuntaController(ApplicationDbContext context) => _context = context;

    public IActionResult BuscarVotante() => View();

    [HttpPost]
    public IActionResult BuscarVotante(string cedula)
    {
        var votante = _context.Votantes.FirstOrDefault(v => v.Cedula == cedula);
        if (votante == null)
        {
            ViewBag.Error = "Votante no encontrado";
            return View();
        }

        votante.CodigoVotacion = Guid.NewGuid().ToString("N")[..6].ToUpper();
        _context.SaveChanges();

        ViewBag.Codigo = votante.CodigoVotacion;
        ViewBag.Mesa = votante.Mesa;

        return View();
    }
}