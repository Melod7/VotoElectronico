using System;
using System.Linq;

namespace VotoElectronico.API.Services
{
    public class CodigoService
    {
        public static string GenerarCodigo()
        {
            const string caracteres = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();

            return new string(
                Enumerable.Repeat(caracteres, 6)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
        }
    }
}