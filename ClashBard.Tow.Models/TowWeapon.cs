using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace ClashBard.Tow.Models;

public class TowWeapon: TowObjectWithSpecialRules
{
    public TowWeapon(TowObject owner, TowWeaponType weaponType, int? range, TowWeaponStrength strength, int armorPiercing)
        :base(owner)
    {
        WeaponType = weaponType;
        Range = range;
        Strength = strength;
        ArmorPiercing = armorPiercing;
    }

    public TowWeaponType WeaponType { get; set; }

    public int? Range { get; set; } = 0; // 0 means range "Combat"

    public TowWeaponStrength Strength { get; set; }

    public int ArmorPiercing { get; set; }

    public override string GetSpecialRulesShortDescription()
    {
        StringBuilder shortDescriptionSb = new();
        string separator = ClashBardStatic.Separator;

        if(Range.HasValue && Range.Value > 0)
        {
            shortDescriptionSb.Append($"{Range}\"{separator}");
        }

        shortDescriptionSb.Append($"{Strength.ToDescriptionString()}{separator}");

        if(ArmorPiercing > 0)
        {
            shortDescriptionSb.Append($"AP -{ArmorPiercing}{separator}");
        }

        shortDescriptionSb.Append(base.GetSpecialRulesShortDescription());

        return shortDescriptionSb.ToString().TrimEnd(separator.ToCharArray());
    }

}

public enum TowWeaponStrength
{
    [Description("S")]
    S = 1,
    [Description("S+1")]
    Splus1,
    [Description("S+2")]
    Splus2,
    [Description("S+3")]
    Splus3,
    [Description("S:2")]
    Two,
    [Description("S:3")]
    Three,
    [Description("S:4")]
    Four,
    [Description("S:5")]
    Five,
    [Description("S:6")]
    Six,
    [Description("S:10")]
    Ten,
    [Description("S:*")]
    Special,
}
