namespace VotoElectronico.MVC.ViewModels
{
    public class ValidarCodigoViewModel
    {
        public string Cedula { get; set; } = string.Empty;
        public string CodigoIngresado { get; set; } = string.Empty;
        public string? Error { get; set; }
    }
}
