namespace VotoElectronicoo.API.DTOs.Resultados
{
    public class ResultadoDTO
    {
        public string Partido { get; set; } = "";
        public int TotalVotos { get; set; }
        public string NombreCandidato { get; set; } = "";
        public string FotoUrl { get; set; } = "";
    }
}
