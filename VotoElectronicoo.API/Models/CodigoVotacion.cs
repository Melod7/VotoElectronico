using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotoElectronicoo.API.Models
{
    [Table("CodigoVotacion")]
    public class CodigoVotacion
    {
        [Key]
        public int Id { get; set; }

        public string Cedula { get; set; } = string.Empty;

        public string Codigo { get; set; } = string.Empty;

        public bool Usado { get; set; } = false;

        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
