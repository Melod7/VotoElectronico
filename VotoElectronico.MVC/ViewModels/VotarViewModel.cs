using System.ComponentModel.DataAnnotations;
using VotoElectronico.MVC.Models;

namespace VotoElectronico.MVC.ViewModels
{
    public class VotarViewModel
    {
        public int VotanteId { get; set; }

        public int PartidoId { get; set; }

        public List<Partido> Partidos { get; set; } = new();
        public int PartidoSeleccionadoId { get; set; }
        public string Error { get; set; } = string.Empty;

    }
}