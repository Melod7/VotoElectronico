namespace VotoElectronicoo.API.DTOs.Auth
{
    public class LoginCodigoDTO
    {
        public string Cedula { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public int CandidatoId { get; set; }
    }
}
