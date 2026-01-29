namespace VotoElectronicoo.API.Models
{
    public class CodigoAutenticacion
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;

        public DateTime FechaExpiracion { get; set; }
        public bool Estado { get; set; }

        public bool Usado { get; set; }


    }
}
