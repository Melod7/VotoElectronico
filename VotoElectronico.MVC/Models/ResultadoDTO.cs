namespace VotoElectronico.MVC.Models
{
    public class ResultadoDTO
    {
        public string Partido { get; set; } = "";
        public int TotalVotos { get; set; }
        public string NombreCandidato { get; set; } = "";   
        public string FotoUrl { get; set; } = "";  
        public double Porcentaje { get; set; }
    }
}
