using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowModelAdditional: TowObjectWithSpecialRules
{
    public TowModelAdditional(Enum modelType, int? m, int ws, int? bs, int s, int? t, int? w, int i, int a, int? ld, /*int pointCost,*/ /*TowModelTroopType modelTroopType,*/ TowFaction faction)
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

    public virtual ICollection<TowWeapon> Weapons { get; protected set; } = new List<TowWeapon>() { new HandWeaponTowWeapon() };

    public virtual ICollection<TowArmour> Armours { get; protected set; } = new List<TowArmour>() { };

    public Enum ModelType { get; set; }

    //public virtual required int FactionId { get; set; }
    public virtual TowFaction Faction { get; set; }
}
