using System.Text.RegularExpressions;

namespace ProConsulta.Extensions
{
    public static class StringExtension
    {
        public static string RemoverCaracteresEspeciais(this string input)
        {
            if(string.IsNullOrEmpty(input))
                return input;

            string pattern = @"[-\.\(\)\s]";

            string resultado = Regex.Replace(input, pattern, string.Empty);

            return resultado;
        }
    }
}
