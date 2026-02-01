namespace VotoElectronico.MVC.Models
{
    public class Voto
    {
        public int Id { get; set; }
        public int PartidoId { get; set; }
        public DateTime Fecha { get; set; }
    }
}