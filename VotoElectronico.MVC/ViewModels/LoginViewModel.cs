using System.Data.SqlTypes;

namespace VotoElectronico.MVC.Models.ViewModels
{
    public class LoginViewModel
    {
        public string Cedula { get; set; } = string.Empty;
        public string CodigoGenerado { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
    }
}
