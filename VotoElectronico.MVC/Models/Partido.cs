using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace VotoElectronico.MVC.Models
{
    public class Partido
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public string LogoUrl { get; set; } = string.Empty;

        public List<Candidato> Candidatos { get; set; } = new();
    }
}