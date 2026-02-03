namespace VotoElectronicoo.API.DTOs
{
    public class BitacoraDTO
    {
        public DateTime Fecha { get; set; }
        public string Rol { get; set; } = string.Empty;
        public string Accion { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string? Ip { get; set; }
    }
}
