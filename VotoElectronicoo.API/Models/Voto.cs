namespace VotoElectronicoo.API.Models
{
    public class Voto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int EleccionId { get; set; } 
        public Eleccion Eleccion { get; set; } = null!;

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; } = null!;
        public int VotanteId { get; set; }
        public Votante Votante { get; set; } = null!;

    }
}
