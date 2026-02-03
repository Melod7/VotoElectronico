using System.Data;

namespace VotoElectronico.MVC.Models
{
    public class Voto
    {
        public int Id { get; set; }
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; } = null!;
        public DateTime Fecha { get; set; } = DateTime.Now;

        public int PartidoId { get; set; }
        public Partido Partido { get; set; } = null!;
    }
}
