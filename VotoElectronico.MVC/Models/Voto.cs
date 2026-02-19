using System.Data;

namespace VotoElectronico.MVC.Models
{
    public class Voto
    {
        public int Id { get; set; }
        public int CandidatoId { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }
}