using VotoElectronico.MVC.Models;

namespace VotoElectronico.MVC.Models
{
    public class VotacionViewModel
    {
        public string Cedula { get; set; } = "";
        public string Codigo { get; set; } = "";
        public int IdCandidato { get; set; }

        public List<Candidato> Candidatos { get; set; } = new List<Candidato>();

        public string Mensaje { get; set; } = "";
    }
}