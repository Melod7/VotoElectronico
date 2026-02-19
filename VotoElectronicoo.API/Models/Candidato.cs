using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotoElectronicoo.API.Models
{
    [Table("Candidatos")]
    public class Candidato
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Cargo")]
        public string Cargo { get; set; } = "";

        [Column("Partido")]
        public string Partido { get; set; } = "";

        [Column("EleccionId")]
        public int EleccionId { get; set; }

        [Column("NombrePresidente")]
        public string NombrePresidente { get; set; } = "";

        [Column("NombreVicepresidente")]
        public string NombreVicepresidente { get; set; } = "";

        [Column("FotoPresidente")]
        public string FotoPresidente { get; set; } = "";

        [Column("FotoVicepresidente")]
        public string FotoVicepresidente { get; set; } = "";
    }
}