using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowModelAdditional: TowObjectWithSpecialRules
{
    public TowModelAdditional(TowObject owner, Enum modelType, int? m, int ws, int? bs, int s, int? t, int? w, int i, int a, int? ld, /*int pointCost,*/ /*TowModelTroopType modelTroopType,*/ TowFaction faction)
        :base(owner)
    {
        ModelType = modelType;
        Movement = m;
        WeaponSkill = ws;
        BallisticSkill = bs;
        Strength = s;
        Toughness = t;
        Wounds = w;
        Initiative = i;
        Attacks = a;
        Leadership = ld;
        //PointCost = pointCost;
        //ModelTroopType = modelTroopType;
        Faction = faction;

        // add default hand weapon
        Assign(new HandWeaponTowWeapon(this));
    }

    public int? Movement { get; set; }
    public int WeaponSkill { get; set; }
    public int? BallisticSkill { get; set; }
    public int Strength { get; set; }
    public int? Toughness { get; set; }
    public int? Wounds { get; set; }
    public int Initiative { get; set; }
    public int Attacks { get; set; }
    public int? Leadership { get; set; }

    private ICollection<TowWeapon> Weapons { get; set; } = new List<TowWeapon>() { };

    private ICollection<TowArmour> Armours { get; set; } = new List<TowArmour>() { };

    public void Assign(TowWeapon weapon)
    {
        Weapons.Add(weapon);
    }

    public void Assign(TowArmour armour)
    {
        Armours.Add(armour);
    }

    public ICollection<TowWeapon> GetWeapons(bool excludeHandWeapon = true)
    {
        return Weapons.Where(p => excludeHandWeapon ? p.WeaponType != TowWeaponType.HandWeapon : true).ToList();
    }

    public Enum ModelType { get; set; }

    public TowFaction Faction { get; set; }
}
