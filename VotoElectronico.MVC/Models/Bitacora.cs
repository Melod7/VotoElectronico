namespace VotoElectronico.MVC.Models
{
    public class Bitacora
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = "";
        public string Rol { get; set; } = "";
        public string Accion { get; set; } = "";
        public DateTime Fecha { get; set; }
        public int Mesa { get; set; }
        public string Recinto { get; set; } = "";
    }
}
