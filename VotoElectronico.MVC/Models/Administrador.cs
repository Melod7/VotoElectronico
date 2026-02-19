namespace VotoElectronico.MVC.Models
{
    public class Administrador
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string Rol { get; set; } = "Administrador";
    }
}
