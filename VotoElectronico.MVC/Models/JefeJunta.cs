namespace VotoElectronico.MVC.Models
{
    public class JefeJunta
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;  
        public string Mesa { get; set; } = string.Empty;
        public string Rol { get; set; } = "JefeJunta";
        public string Codigo { get; set; } = string.Empty;


    }
}
