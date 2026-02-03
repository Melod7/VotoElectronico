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
        public string Mesa { get; set; } = string.Empty;

        public string? CodigoVotacion { get; set; }
        public DateTime? CodigoExpira { get; set; }

        public bool YaVoto { get; set; }
    }
}




        