
namespace TextReader
{
    public class HtmlParser
    {
        public static string Parse(string text)
        {
            var result = text.Split("<div").Length;
            return $"{nameof(HtmlParser)}-{result}";
        }
    }
}
