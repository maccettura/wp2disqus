using System.Globalization;
using System.Text.RegularExpressions;

namespace DisqusConvert.Extensions;

public static partial class StringExtensions
{
    [GeneratedRegex(@"<!\s*\[CDATA\s*\[(?<text>(?>[^]]+|](?!]>))*)]]>")]
    private static partial Regex CDataRegex();

    public static string FromCdata(this string input)
    {
        if (input == null)
        {
            return string.Empty;
        }

        var match = CDataRegex().Match(input);

        if (match.Success)
        {
            return match.Groups[1].Value;
        }

        return input;
    }

    public static DateTime? ToDateTime(this string input, string format = "ddd, dd MMM yyyy hh:mm:ss")
    {
        if(string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        if(!DateTime.TryParseExact(input, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime output))
        {
            if(!DateTime.TryParse(input, out output))
            {
                Console.WriteLine($"Could not parse {input}");
                return null;
            }
        }
        return output;
    }

    const string CDataTrue = "<![CDATA[1]]>";
    public static bool CDataBool(this string input)
    {
        if(input == null)
        {
            return false;
        }
        if(input == "1" || CDataTrue.Equals(input))
        {
            return true;
        }
        return false;
    }
}
