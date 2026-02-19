using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotoElectronicoo.API.Models
{
    public class Votante
    {
        public int Id { get; set; }

        [Required]
        public string Cedula { get; set; } = "";

        public string Nombres { get; set; } = "";

        public string Apellidos { get; set; } = "";

        public string? Correo { get; set; }

        public string? CodigoVotacion { get; set; }

        public DateTime? CodigoExpira { get; set; }

        public bool YaVoto { get; set; } = false;

        public int Mesa { get; set; }   
        public string Recinto { get; set; } = "";

    }
}