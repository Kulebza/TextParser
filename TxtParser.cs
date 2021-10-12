using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextReader
{
    public class TxtParser
    {
        public static string Parse(string text)
        {
            string pattern = @"[\p{P}]";
            var regex = new Regex(pattern);
            var count = regex.Matches(text).Count;
            return $"{nameof(TxtParser)}-{count}";
        }
    }
}
