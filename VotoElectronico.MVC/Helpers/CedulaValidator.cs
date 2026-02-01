namespace VotoElectronico.MVC.Helpers
{
    public static class CedulaValidator
    {
        public static bool EsCedulaValida(string cedula)
        {
            if (cedula.Length != 10 || !cedula.All(char.IsDigit))
                return false;

            int provincia = int.Parse(cedula.Substring(0, 2));
            if (provincia < 1 || provincia > 24)
                return false;

            int[] coef = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int suma = 0;

            for (int i = 0; i < 9; i++)
            {
                int val = (cedula[i] - '0') * coef[i];
                if (val >= 10) val -= 9;
                suma += val;
            }

            int digitoVerificador = (10 - (suma % 10)) % 10;
            return digitoVerificador == (cedula[9] - '0');
        }
    }
}