using System.Text;

namespace VotoElectronico.MVC.Helpers
{
    public static class CodigoHelper
    {
        public static string GenerarCodigo()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 6; i++)
                sb.Append(chars[rnd.Next(chars.Length)]);

            return sb.ToString();
        }
    }
}