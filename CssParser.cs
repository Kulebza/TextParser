using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReader
{
    public static class CssParser
    {
        public static string Parse(string text)
        {
            var result = text.Count(x => x == '{') == text.Count(x => x == '}');
            return $"{nameof(CssParser)}-{result}";
        }
    }
}
