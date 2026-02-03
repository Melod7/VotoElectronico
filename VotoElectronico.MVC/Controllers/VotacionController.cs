using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotoElectronico.MVC.Data;
using VotoElectronico.MVC.Models;
using System;

public class VotacionController : Controller
{
    private readonly ApplicationDbContext _context;
    public VotacionController(ApplicationDbContext context) => _context = context;

    public IActionResult Index()
    {
        var votanteId = HttpContext.Session.GetInt32("VotanteId");

        if (votanteId == null)
            return RedirectToAction("Votante", "Auth");

        var candidatos = _context.Candidatos.ToList();
        return View(candidatos);
    }

    [HttpPost]
    public IActionResult Votar(int candidatoId)
    {
        var votanteId = HttpContext.Session.GetInt32("VotanteId");
        if (votanteId == null)
            return RedirectToAction("Votante", "Auth");

        var votante = _context.Votantes.Find(votanteId);
        if (votante == null || votante.YaVoto)
            return RedirectToAction("Votante", "Auth");

        var voto = new Voto
        {
            CandidatoId = candidatoId,
            Fecha = DateTime.Now
        };

        _context.Votos.Add(voto);

        votante.YaVoto = true;
        votante.CodigoVotacion = null;
        votante.CodigoExpira = null;

        _context.SaveChanges();

        HttpContext.Session.Clear();

        return RedirectToAction("Gracias");
    }
}

    