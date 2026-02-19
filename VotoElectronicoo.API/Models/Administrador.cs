using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotoElectronicoo.API.Models
{
    [Table("administradores")] 
    public class Administrador
    {
        [Key]
        [Column("id")] 
        public int Id { get; set; }

        [Column("correo")]
        public string Correo { get; set; } = string.Empty;

        [Column("password")]
        public string Password { get; set; } = string.Empty;
    }
}