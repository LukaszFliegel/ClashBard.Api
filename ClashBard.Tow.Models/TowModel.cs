using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowModel
{   
    public TowModel(Enum modelType, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld, int pointCost, TowModelTroopType modelTroopType/*, TowModelSlotType modelSlotType*/, TowFaction faction,
        int minUnitSize = 1, int? maxUnitSize = null)
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
        PointCost = pointCost;
        ModelTroopType = modelTroopType;
        //ModelSlotType = modelSlotType;
        Faction = faction;
        SetDefaultBaseSize();
        MinUnitSize = minUnitSize;
        MaxUnitSize = maxUnitSize;
    }

    public TowModel(Enum modelType, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld, int pointCost, TowModelTroopType modelTroopType/*, TowModelSlotType modelSlotType*/, TowFaction faction, 
        int baseSizeWidth, int baseSizeLength, 
        int minUnitSize = 1, int? maxUnitSize = null)
        : this(modelType, m, ws, bs, s, t, w, i, a, ld, pointCost, modelTroopType/*, modelSlotType*/, faction, minUnitSize, maxUnitSize)
    {
        BaseSizeWidth = baseSizeWidth;
        BaseSizeLength = baseSizeLength;
    }

    public Enum ModelType { get; set; }
    public int? Movement { get; set; }
    public int WeaponSkill { get; set; }
    public int BallisticSkill { get; set; }
    public int Strength { get; set; }
    public int Toughness { get; set; }
    public int Wounds { get; set; }
    public int Initiative { get; set; }
    public int Attacks { get; set; }
    public int Leadership { get; set; }

    public TowModel? ChampionModel { get; set; }
    public string? ChampionName { get; set; }
    public int? ChampionUpgradeCost { get; set; }
    public int? MagicStandardUpToPoints { get; set; }
    public int? StandardBearerUpgradeCost { get; set; }
    public int? MusicianUpgradeCost { get; set; }

    public void AssignCommandGroupCost(TowModel championModel, int? championUpgradeCost, int? standardBearerUpgradeCost, int? musicianUpgradeCost, int? magicStandardUpToPoints = null, string championName = "Champion")
    {
        ChampionModel = championModel;
        ChampionUpgradeCost = championUpgradeCost;
        StandardBearerUpgradeCost = standardBearerUpgradeCost;
        MusicianUpgradeCost = musicianUpgradeCost;
        MagicStandardUpToPoints = magicStandardUpToPoints;
        ChampionName = championName;
    }

    public int BaseSizeWidth { get; set; }
    public int BaseSizeLength { get; set; }

    //public virtual ICollection<(TowWeaponType, int)> AvailableWeapons { get; protected set; } = new HashSet<(TowWeaponType, int)>() {  };
    public virtual ICollection<TowOption<TowWeaponType>> AvailableWeapons { get; protected set; } = new HashSet<TowOption<TowWeaponType>>() { };
    public virtual ICollection<TowWeapon> Weapons { get; protected set; } = new List<TowWeapon>() { new HandWeaponTowWeapon() };

    public virtual ICollection<(TowArmorType, int)> AvailableArmors { get; protected set; } = new HashSet<(TowArmorType, int)>() { };   
    public virtual ICollection<TowArmor> Armors { get; protected set; } = new List<TowArmor>() { };

    public int PointCost { get; set; }
    //public TowModelSlotType ModelSlotType { get; set; }

    public TowModelTroopType ModelTroopType { get; set; }
    public int MinUnitSize { get; set; }
    public int? MaxUnitSize { get; set; }

    public virtual TowModelMount? Mount { get; set; }
    public virtual ICollection<TowModelAdditional>? Crew { get; set; }


    public virtual TowFaction Faction { get; set; }

    public virtual ICollection<(TowSpecialRuleType, int)> AvailableSpecialRules { get; set; } = new HashSet<(TowSpecialRuleType, int)>() { };
    public virtual ICollection<TowSpecialRule> SpecialRules { get; set; } = new HashSet<TowSpecialRule>() { };


    //public void AddAvailableWeapon(TowWeaponType weaponType, int points)
    //{
    //    AvailableWeapons.Add((weaponType, points));
    //}

    //public void RemoveAvailableWeapon(TowWeaponType weaponType, int points)
    //{
    //    AvailableWeapons.Remove((weaponType, points));
    //}

    public void AssignWeapon(TowWeapon weapon)
    {
        if (!AvailableWeapons.Any(w => w.Item1 == weapon.WeaponType))
        {
            throw new Exception($"Weapon {weapon.WeaponType} not available for {ModelType} model");
        }

        Weapons.Add(weapon);
    }

    private void SetDefaultBaseSize()
    {
        switch (ModelTroopType)
        {
            case TowModelTroopType.RegularInfantry:
                BaseSizeLength = 25;
                BaseSizeWidth = 25;
                break;
            case TowModelTroopType.MonstrousInfantry:
                BaseSizeLength = 40;
                BaseSizeWidth = 40;
                break;
            case TowModelTroopType.LightCavalry:
                BaseSizeLength = 60;
                BaseSizeWidth = 30;
                break;
            case TowModelTroopType.HeavyCavalry:
                BaseSizeLength = 60;
                BaseSizeWidth = 30;
                break;
            case TowModelTroopType.MonstrousCavalry:
                BaseSizeLength = 100;
                BaseSizeWidth = 50;
                break;
            case TowModelTroopType.MonstrousCreature:
                BaseSizeLength = 50;
                BaseSizeWidth = 50;
                break;
            case TowModelTroopType.WarMachine:
                BaseSizeLength = 50;
                BaseSizeWidth = 50;
                break;
            case TowModelTroopType.HeavyChariot:
                BaseSizeLength = 100;
                BaseSizeWidth = 60;
                break;
            case TowModelTroopType.LightChariot:
                BaseSizeLength = 100;
                BaseSizeWidth = 50;
                break;
            case TowModelTroopType.Behemoth:
                BaseSizeLength = 100;
                BaseSizeWidth = 60;
                break;
            case TowModelTroopType.WarBeast:
                BaseSizeLength = 50;
                BaseSizeWidth = 25;
                break;
        }
    }
}

//public enum TowModelSlotType
//{
//    Character = 1,
//    Core,
//    Special,
//    Rare,
//}

public enum TowModelTroopType
{     
    //Undefined = 0,
    RegularInfantry = 1,
    MonstrousInfantry,
    LightCavalry,    
    HeavyCavalry,
    MonstrousCavalry,
    MonstrousCreature,
    WarMachine,
    HeavyChariot,
    LightChariot,
    Behemoth,
    WarBeast,
}
