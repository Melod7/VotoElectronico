namespace VotoElectronico.MVC.Models
{
    public class Eleccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Activa { get; set; }    
    }
}
