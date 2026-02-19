namespace VotoElectronico.MVC.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Cargo { get; set; } = "";
        public string Partido { get; set; } = "";
        public int EleccionId { get; set; }

        public string NombrePresidente { get; set; } = "";
        public string NombreVicepresidente { get; set; } = "";

        public string FotoPresidente { get; set; } = "";
        public string FotoVicepresidente { get; set; } = "";
    }
}