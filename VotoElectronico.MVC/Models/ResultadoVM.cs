namespace VotoElectronico.MVC.Models
{
    public class ResultadoVM
    {
        public string Partido { get; set; } = string.Empty;
        public int Votos { get; set; }
        public double Porcentaje { get; set; } 
        public int TotalVotos { get; set; }
        public string NombreCandidato { get; set; } = string.Empty;
    }
}
