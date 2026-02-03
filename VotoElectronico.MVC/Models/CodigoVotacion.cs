namespace VotoElectronico.MVC.Models
{
    public class CodigoVotacion
    {
        public int Id { get; set; } 
        public string Codigo { get; set; } = string.Empty;
        public DateTime Expira { get; set; }
        public bool Usado { get; set; } = false;
        public int VotanteId { get; set; }
    }
}
