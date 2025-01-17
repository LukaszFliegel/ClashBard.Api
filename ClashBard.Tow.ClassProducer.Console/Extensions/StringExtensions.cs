using System;
using System.Globalization;
using System.Text;

public static class StringExtensions
{
    public static string ToLegalClassName(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        str = str.Trim().Replace("*", string.Empty).Replace("'", string.Empty);

        var textInfo = CultureInfo.CurrentCulture.TextInfo;
        var words = str.Split(new[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
        var sb = new StringBuilder();

        foreach (var word in words)
        {
            sb.Append(textInfo.ToTitleCase(word.ToLower()));
        }

        return sb.ToString();
    }
}
