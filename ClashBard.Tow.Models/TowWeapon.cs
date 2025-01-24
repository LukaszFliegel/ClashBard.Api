using ClashBard.Tow.Models.TowTypes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
    [Description("2")]
    Two,
    [Description("3")]
    Three,
    [Description("4")]
    Four,
    [Description("5")]
    Five,
    [Description("6")]
    Six,
    [Description("10")]
    Ten,
    [Description("*")]
    Special,
}
