namespace VotoElectronicoo.API.Models
{
    public class Eleccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

    }
}
