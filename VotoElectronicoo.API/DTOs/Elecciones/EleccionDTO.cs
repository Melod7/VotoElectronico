namespace VotoElectronicoo.API.DTOs.Elecciones
{
    public class EleccionDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Activa { get; set; }
    }
}
