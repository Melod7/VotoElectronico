using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotoElectronicoo.API.Models
{
    [Table("jefejunta")]
    public class JefeJunta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("correo")]
        public string Correo { get; set; } = string.Empty;

        [Column("clave")]
        public string Clave { get; set; }= string.Empty;

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;
    }
}