using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace ClashBard.Tow.Models;

public class TowModel: TowObjectWithSpecialRules
{   
    public TowModel(Enum modelType, int? m, int? ws, int? bs, int? s, int t, int w, int? i, int? a, int? ld, int pointCost, TowModelTroopType modelTroopType/*, TowModelSlotType modelSlotType*/, TowFaction faction,
        int minUnitSize = 1, int? maxUnitSize = null, int? armorValue = null)
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
        ArmorValue = armorValue;
    }

    public TowModel(Enum modelType, int? m, int? ws, int? bs, int? s, int t, int w, int? i, int? a, int? ld, int pointCost, TowModelTroopType modelTroopType/*, TowModelSlotType modelSlotType*/, TowFaction faction, 
        int baseSizeWidth, int baseSizeLength, 
        int minUnitSize = 1, int? maxUnitSize = null, int? armorValue = null)
        : this(modelType, m, ws, bs, s, t, w, i, a, ld, pointCost, modelTroopType/*, modelSlotType*/, faction, minUnitSize, maxUnitSize, armorValue)
    {
        BaseSizeWidth = baseSizeWidth;
        BaseSizeLength = baseSizeLength;
    }

    public Enum ModelType { get; set; }
    public int? Movement { get; set; }
    public int? WeaponSkill { get; set; }
    public int? BallisticSkill { get; set; }
    public int? Strength { get; set; }
    public int Toughness { get; set; }
    public int Wounds { get; set; }
    public int? Initiative { get; set; }
    public int? Attacks { get; set; }
    public int? Leadership { get; set; }

    public int PointCost { get; set; }

    public int? ArmorValue { get; set; }

    public TowModel? ChampionModel { get; private set; }
    public string? ChampionName { get; private set; }
    public int? ChampionMagicItemsUpToPoints { get; private set; }
    public int? ChampionUpgradeCost { get; private set; }
    public int? MagicStandardUpToPoints { get; private set; }
    public int? StandardBearerUpgradeCost { get; private set; }
    public int? MusicianUpgradeCost { get; private set; }

    public void SetCommandGroup(TowModel? championModel, int? championUpgradeCost, int? standardBearerUpgradeCost, int? musicianUpgradeCost, int? magicStandardUpToPoints = null, string? championName = null, int? championMagicItemsUpToPoints = null)
    {
        ChampionModel = championModel;
        ChampionUpgradeCost = championUpgradeCost;
        ChampionName = championName;
        championModel.ChampionName = championName;
        championModel.PointCost = championUpgradeCost.Value;
        ChampionMagicItemsUpToPoints = championMagicItemsUpToPoints;

        StandardBearerUpgradeCost = standardBearerUpgradeCost;

        MusicianUpgradeCost = musicianUpgradeCost;
        MagicStandardUpToPoints = magicStandardUpToPoints;
        
    }    

    public int BaseSizeWidth { get; set; }
    public int BaseSizeLength { get; set; }

    public virtual ICollection<(TowWeaponType, int)> AvailableWeapons { get; protected set; } = new HashSet<(TowWeaponType, int)>() { };
    public virtual ICollection<TowOption<TowWeaponType>> OptionalWeapons { get; protected set; } = new List<TowOption<TowWeaponType>>() { };
    //public virtual ICollection<TowOption<TowWeaponType>> AvailableWeapons { get; protected set; } = new HashSet<TowOption<TowWeaponType>>() { };
    public virtual ICollection<TowWeapon> Weapons { get; protected set; } = new List<TowWeapon>() { new HandWeaponTowWeapon() };

    public virtual ICollection<(TowArmorType, int)> AvailableArmors { get; protected set; } = new HashSet<(TowArmorType, int)>() { };   
    public virtual ICollection<TowArmor> Armors { get; protected set; } = new List<TowArmor>() { };
    
    //public TowModelSlotType ModelSlotType { get; set; }

    public TowModelTroopType ModelTroopType { get; set; }
    public int MinUnitSize { get; set; }
    public int? MaxUnitSize { get; set; }

    public virtual TowModelMount? Mount { get; set; }
    public virtual ICollection<TowModelAdditional> Crew { get; set; } = new HashSet<TowModelAdditional>();


    public virtual TowFaction Faction { get; set; }

    public virtual ICollection<(TowSpecialRuleType, int)> AvailableSpecialRules { get; set; } = new HashSet<(TowSpecialRuleType, int)>() { };

    public string GetMeleeSaveString()
    {
        if (GetMeleeSave().HasValue)
        {
            if (GetRangedSave().HasValue && GetMeleeSave() != GetRangedSave())
                return $"{GetMeleeSave()}/{GetRangedSave()}";
            else
                return $"{GetMeleeSave()}";
        }
        else
            return string.Empty;
    }

    public string GetMagicSaveString()
    {
        if (GetMagicMeleeSave().HasValue)
        {
            if (GetMagicRangedSave().HasValue && GetMagicMeleeSave() != GetMagicRangedSave())
                return $"{GetMagicMeleeSave()}/{GetMagicRangedSave()}";
            else
                return $"{GetMagicMeleeSave()}";
        }
        else
            return string.Empty;
    }

    public int? GetMeleeSave()
    {
        int save = 0;

        // take the highest MeleeSaveBaseline from all armors
        save = Armors.Count > 0 ? Armors.Max(a => a.MeleeSaveBaseline) : 0;

        // add all MeleeSaveImprovements from all armors
        foreach (var armor in Armors)
        {
            save -= armor.MeleeSaveImprovement;
        }

        return save > 0 ? save : null;
    }

    public int? GetRangedSave()
    {
        int save = 0;

        // take the highest RangedSaveBaseline from all armors
        save = Armors.Count > 0 ? Armors.Max(a => a.RangedSaveBaseline) : 0;

        // add all RangedSaveImprovements from all armors
        foreach (var armor in Armors)
        {
            save -= armor.RangedSaveImprovement;
        }
        return save > 0 ? save : null;
    }

    public int? GetMagicMeleeSave()
    {
        int save = 0;

        // take the highest MagicMeleeSaveBaseline from all armors
        save = Armors.Count > 0 ? Armors.Max(a => a.MagicMeleeSaveBaseline) : 0;

        // add all MagicMeleeSaveImprovements from all armors
        foreach (var armor in Armors)
        {
            save -= armor.MagicMeleeSaveImprovement;
        }
        return save > 0 ? save : null;
    }

    public int? GetMagicRangedSave()
    {
        int save = 0;

        // take the highest MagicRangedSaveBaseline from all armors
        save = Armors.Count > 0 ? Armors.Max(a => a.MagicRangedSaveBaseline) : 0;

        // add all MagicRangedSaveImprovements from all armors
        foreach (var armor in Armors)
        {
            save -= armor.MagicRangedSaveImprovement;
        }
        return save > 0 ? save : null;
    }

    public void SetWeapon(TowWeapon weapon)
    {
        if (!AvailableWeapons.Any(w => w.Item1 == weapon.WeaponType))
        {
            throw new Exception($"Weapon {weapon.WeaponType} not available for {ModelType} model");
        }

        Weapons.Add(weapon);
    }

    public void SetArmor(TowArmor armor)
    {
        if (!AvailableArmors.Any(a => a.Item1 == armor.ArmorType))
        {
            throw new Exception($"Armor {armor.ArmorType} not available for {ModelType} model");
        }
        Armors.Add(armor);
    }

    public void SetSpecialRule(TowSpecialRule specialRule)
    {
        if (!AvailableSpecialRules.Any(sr => sr.Item1 == specialRule.RuleType))
        {
            throw new Exception($"Special rule {specialRule.RuleType} not available for {ModelType} model");
        }
        SpecialRules.Add(specialRule);
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
            case TowModelTroopType.Swarm:
                BaseSizeLength = 999;
                BaseSizeWidth = 999;
                break;
            default:
                throw new Exception("Unknown model type");
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
    Swarm,
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

public static class TowModelTroopTypeExtensions
{
    public static int UnitStrength(this TowModelTroopType troopType)
    {
        switch (troopType)
        {
            case TowModelTroopType.RegularInfantry:
                return 1;
            case TowModelTroopType.MonstrousInfantry:
                return 1;
            case TowModelTroopType.LightCavalry:
                return 1;
            case TowModelTroopType.HeavyCavalry:
                return 1;
            case TowModelTroopType.MonstrousCavalry:
                return 1;
            case TowModelTroopType.MonstrousCreature:
                return 1;
            case TowModelTroopType.WarMachine:
                return 1;
            case TowModelTroopType.HeavyChariot:
                return 1;
            case TowModelTroopType.LightChariot:
                return 1;
            case TowModelTroopType.Behemoth:
                return 1;
            case TowModelTroopType.WarBeast:
                return 1;
            case TowModelTroopType.Swarm:
                return 1;
            default:
                throw new Exception("Unknown model type");
        }
    }
}
