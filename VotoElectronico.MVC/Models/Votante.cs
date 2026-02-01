namespace VotoElectronico.MVC.Models
{
    public class Votante
    {
        public int Id { get; set; }

        public required string Cedula { get; set; }

        public required string Nombres { get; set; }

        public required string Apellidos { get; set; }

        public bool YaVoto { get; set; }
    }
}