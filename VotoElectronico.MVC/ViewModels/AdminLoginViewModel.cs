namespace VotoElectronico.MVC.ViewModels
{
    public class AdminLoginViewModel
    {
        public string Correo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
    }
}