using System.ComponentModel.DataAnnotations;

namespace VotoElectronico.MVC.Models
{
    public class Candidato
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Cargo { get; set; } = string.Empty;

        public int PartidoId { get; set; }
        public Partido Partido { get; set; } = null!;

    }
}