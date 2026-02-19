using System.Text;

public static class CodigoHelper
{
    public static string GenerarCodigo(int longitud = 6)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var sb = new StringBuilder();

        for (int i = 0; i < longitud; i++)
            sb.Append(chars[random.Next(chars.Length)]);

        return sb.ToString();
    }
}