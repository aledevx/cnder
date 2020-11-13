using System;

namespace CNDer.Helpers
{
    public class FormatadorData
    {
        public static string FormatarData(DateTime? data){
            return data.ToString().Substring(0,10);
        }
    }
}