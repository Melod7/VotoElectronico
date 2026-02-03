using System.Collections.Generic;
using VotoElectronico.MVC.Models;
public class VotacionViewModel
{
    public List<Partido> Partidos { get; set; } = new();
    public int PartidoId { get; set; }
    public string PartidoNombre { get; set; } = string.Empty;
    public  string? Presidente { get; set; } 
    public  string? Vicepresidente { get; set; } 
}