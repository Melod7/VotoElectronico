using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using VotoElectronico.MVC.Data;
using VotoElectronico.MVC.Models;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Dashboard
    public IActionResult Index()
    {
        var partidos = _context.Partidos
            .Include(p => p.Candidatos)
            .ToList();

        return View(partidos);
    }

    // Crear partido
    [HttpGet]
    public IActionResult CrearPartido()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CrearPartido(string nombre)
    {
        _context.Partidos.Add(new Partido { Nombre = nombre });
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // Crear candidatos
    [HttpGet]
    public IActionResult CrearCandidatos(int id)
    {
        var partido = _context.Partidos.Find(id);
        return View(partido);
    }

    [HttpPost]
    public IActionResult CrearCandidatos(
        int partidoId,
        string presidente,
        string vicepresidente)
    {
        _context.Candidatos.AddRange(
            new Candidato
            {
                Nombre = presidente,
                Cargo = "Presidente",
                PartidoId = partidoId
            },
            new Candidato
            {
                Nombre = vicepresidente,
                Cargo = "Vicepresidente",
                PartidoId = partidoId
            }
        );

        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
