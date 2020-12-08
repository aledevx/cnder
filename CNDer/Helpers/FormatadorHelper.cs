using System;

namespace CNDer.Helpers
{
    public class FormatadorHelper
    {
        public static string FormatarData(DateTime? data)
        {
            return data.ToString().Substring(0, 10);
        }
        public static string RemoveCaracteresCPF(string text)
        {
            if (text == null)
            {
                return "";
            }
            return text.Replace(".", "").Replace("-", "").Replace("/", "");
        }


    }
}