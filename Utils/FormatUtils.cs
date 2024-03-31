using System.Globalization;

namespace Eplay.Components.Utils
{
    public class FormatUtils
    {
        public static string ConverteValor(double? numero)
        {
            decimal numeroDecimal = Convert.ToDecimal(numero);
            string numeroFormatado = numeroDecimal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
            return numeroFormatado;
        }

        public static string ConvertePorcentagem(int? numero)
        {
            return $"{numero}%";
        }
    }
}
