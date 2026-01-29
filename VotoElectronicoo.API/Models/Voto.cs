namespace VotoElectronicoo.API.Models
{
    public class Voto
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; } = null!;

        public DateTime Fecha { get; set; }
    }
}
