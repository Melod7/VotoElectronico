namespace VotoElectronico.MVC.Models
{
    public class JefeJunta
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Mesa { get; set; } = string.Empty;

        public string? CodigoAcceso { get; set; }
        public DateTime? CodigoExpira { get; set; }
    }
}
