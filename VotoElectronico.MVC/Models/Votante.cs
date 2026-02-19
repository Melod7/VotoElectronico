using System.ComponentModel.DataAnnotations;
using System.Data;

namespace VotoElectronico.MVC.Models
{
    public class Votante
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public int Mesa { get; set; } 
        public bool YaVoto { get; set; }
        public string Partido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Recinto { get; set; } = string.Empty; 
    }
}



