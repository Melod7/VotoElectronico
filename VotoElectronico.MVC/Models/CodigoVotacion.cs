using System;

namespace VotoElectronico.MVC.Models
{
    public class CodigoVotacion
    {
        public int Id { get; set; }

        public string Cedula { get; set; } = string.Empty;

        public string Codigo { get; set; } = string.Empty;

        public bool Usado { get; set; }

        public DateTime Fecha { get; set; }

    }
}
