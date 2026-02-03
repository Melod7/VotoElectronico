namespace VotoElectronico.MVC.ViewModels
{
    public class VotanteLoginViewModel
    {
        public string Cedula { get; set; } = string.Empty;
        public string? CodigoGenerado { get; set; }
        public string? Codigo { get; set; }
        public string? Error { get; set; }
    }
}