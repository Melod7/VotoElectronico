namespace VotoElectronicoo.API.Models
{
    public class Bitacora
    {
        public int Id { get; set; }

        public string Rol { get; set; } = null!;

        public string Accion { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public string? Ip { get; set; }
    }
}

