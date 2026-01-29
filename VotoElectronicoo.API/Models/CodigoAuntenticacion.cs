namespace VotoElectronicoo.API.Models
{
    public class CodigoAuntenticacion
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public DateTime FechaExpiracion { get; set; }
        public bool Estado { get; set; }

        public int UsuarioId { get; set; }
    }
}
