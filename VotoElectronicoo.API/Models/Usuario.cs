namespace VotoElectronicoo.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public bool YaVoto { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; } = null!;

        public string? CodigoVotacion { get; set; } 
        public DateTime? CodigoExpira { get; set; }
    }
}
