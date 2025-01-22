using System.ComponentModel;
using System.Reflection;

namespace ClashBard.Tow.StaticData;

public static class EnumTypeExtensions
{
    public static string ToDescriptionString(this Enum enumvalue)
    {
        FieldInfo fi = enumvalue.GetType().GetField(enumvalue.ToString());

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
            return attributes[0].Description;
        else
            return enumvalue.ToString();
    }
}