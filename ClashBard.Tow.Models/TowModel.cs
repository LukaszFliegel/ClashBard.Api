using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ClashBard.Tow.Models;

public class TowModel: TowObjectWithSpecialRules//, IWardSaveBearer
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

    public Enum ModelType { get; private set; }
    public int? Movement { get; private set; }
    public int? WeaponSkill { get; private set; }
    public int? BallisticSkill { get; private set; }
    public int? Strength { get; private set; }
    public int Toughness { get; private set; }
    //protected int _wounds { get; set; }
    //public int Wounds { get { return CalculateTotalWounds(); } private set { _wounds = value; } }
    //public virtual int CalculateTotalWounds()
    //{
    //    return _wounds;
    //}
    public int Wounds { get; set; }
    public int? Initiative { get; private set; }
    public int? Attacks { get; private set; }
    public int? Leadership { get; private set; }

    public int PointCost { get; private set; }

    public int? ArmorValue { get; private set; }

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

    public virtual ICollection<(TowArmourType, int)> AvailableArmours { get; protected set; } = new HashSet<(TowArmourType, int)>() { };   
    public virtual ICollection<TowArmour> Armours { get; protected set; } = new List<TowArmour>() { };
    
    //public TowModelSlotType ModelSlotType { get; set; }

    public TowModelTroopType ModelTroopType { get; set; }
    public int MinUnitSize { get; set; }
    public int? MaxUnitSize { get; set; }

    public virtual TowModelMount? Mount { get; set; }

    public virtual ICollection<(TowModelMountType, int)> AvailableMounts { get; protected set; } = new HashSet<(TowModelMountType, int)>() { };

    public virtual ICollection<TowModelAdditional> Crew { get; set; } = new HashSet<TowModelAdditional>();


    public virtual TowFaction Faction { get; set; }

    public virtual ICollection<(TowSpecialRuleType, int)> AvailableSpecialRules { get; set; } = new HashSet<(TowSpecialRuleType, int)>() { };

    public virtual ICollection<TowMagicItem> MagicItems { get; set; } = new HashSet<TowMagicItem>();

    //public ICollection<IWardSaveImprover> WardSaveImprovers { get; set; } = new HashSet<IWardSaveImprover>();

    //void IWardSaveBearer.RegisterWardSaveImprover(IWardSaveImprover wardSaveImprover)
    //{
    //    WardSaveImprovers.Add(wardSaveImprover);
    //}

    public string GetSaveString()
    {
        if (GetMeleeSave().HasValue)
        {
            if (GetRangedSave().HasValue && GetMeleeSave() != GetRangedSave())
                return $"{GetMeleeSave()}/{GetRangedSave()}{PrintAsteriskfNeededForSave()}";
            else
                return $"{GetMeleeSave()}{PrintAsteriskfNeededForSave()}";
        }
        else
            return string.Empty;
    }

    //public int? GetMeleeWardSave()
    //{
    //    return ((IWardSaveBearer)this).GetMeleeWardSave();
    //}

    //public int? GetRangedWardSave()
    //{
    //    return ((IWardSaveBearer)this).GetRangedWardSave();
    //}

    public string GetWardSaveString()
    {
        if (GetMeleeWardSave().HasValue)
        {
            if (GetRangedWardSave().HasValue && GetMeleeWardSave() != GetRangedWardSave())
                return $"{GetMeleeWardSave()}/{GetRangedWardSave()}{PrintAsteriskfNeededForWardSave()}";
            else
                return $"{GetMeleeWardSave()}{PrintAsteriskfNeededForWardSave()}";
        }
        else
            return string.Empty;
    }

    private string PrintAsteriskfNeededForSave()
    {
        if (Armours.Any(a => a.AsteriskOnSave))
        {
            return "*";
        }

        return string.Empty;
    }

    private string PrintAsteriskfNeededForWardSave()
    {
        if(Armours.Any(a => a.AsteriskOnWardSave))
        {
            return "*";
        }

        return string.Empty;
    }

    

    public int? GetMeleeSave()
    {
        int? save = null;

        var armorsWithProperSave = new List<TowArmour>();

        if(Armours.Any(a => a.MeleeSaveBaseline.HasValue))
            armorsWithProperSave = Armours.Where(a => a.MeleeSaveBaseline.HasValue).ToList();

        // take the highest MeleeSaveBaseline from all armors
        save = armorsWithProperSave.Count > 0 ? armorsWithProperSave.Min(a => a.MeleeSaveBaseline.Value) : null;

        // add all MeleeSaveImprovements from all armors
        foreach (var armor in Armours)
        {
            save -= armor.MeleeSaveImprovement;
        }

        return save > 0 ? save : null;
    }

    public int? GetRangedSave()
    {
        int? save = 0;

        var armorsWithProperSave = new List<TowArmour>();

        if (Armours.Any(a => a.RangedSaveBaseline.HasValue))
            armorsWithProperSave = Armours.Where(a => a.RangedSaveBaseline.HasValue).ToList();

        // take the highest RangedSaveBaseline from all armors
        save = armorsWithProperSave.Count > 0 ? armorsWithProperSave.Min(a => a.RangedSaveBaseline.Value) : null;

        // add all RangedSaveImprovements from all armors
        foreach (var armor in Armours)
        {
            save -= armor.RangedSaveImprovement;
        }
        return save > 0 ? save : null;
    }

    public int? GetMeleeWardSave()
    {
        int? save = 0;

        var armorsWithProperSave = new List<TowArmour>();

        if (Armours.Any(a => a.MeleeWardSaveBaseline.HasValue))
            armorsWithProperSave = Armours.Where(a => a.MeleeWardSaveBaseline.HasValue).ToList();

        // take the highest MagicMeleeSaveBaseline from all armors
        save = armorsWithProperSave.Count > 0 ? armorsWithProperSave.Min(a => a.MeleeWardSaveBaseline.Value) : null;

        // add all MagicMeleeSaveImprovements from all armors
        foreach (var armor in Armours)
        {
            save -= armor.MeleeWardSaveImprovement;
        }
        return save > 0 ? save : null;
    }

    public int? GetRangedWardSave()
    {
        int? save = 0;

        var armorsWithProperSave = new List<TowArmour>();

        if (Armours.Any(a => a.RangedWardSaveBaseline.HasValue))
            armorsWithProperSave = Armours.Where(a => a.RangedWardSaveBaseline.HasValue).ToList();

        // take the highest MagicRangedSaveBaseline from all armors
        save = armorsWithProperSave.Count > 0 ? armorsWithProperSave.Min(a => a.RangedWardSaveBaseline.Value) : null;

        // add all MagicRangedSaveImprovements from all armors
        foreach (var armor in Armours)
        {
            save -= armor.RangedWardSaveImprovement;
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

        if (ChampionModel != null)
        {
            ChampionModel.Weapons.Add(weapon);
        }
    }

    public void SetArmor(TowArmour armor)
    {
        if (!AvailableArmours.Any(a => a.Item1 == armor.ArmorType))
        {
            throw new Exception($"Armor {armor.ArmorType} not available for {ModelType} model");
        }
        Armours.Add(armor);

        if(ChampionModel != null)
        {
            ChampionModel.Armours.Add(armor);
        }
    }

    public void SetSpecialRule(TowSpecialRule specialRule)
    {
        if (!AvailableSpecialRules.Any(sr => sr.Item1 == specialRule.RuleType))
        {
            throw new Exception($"Special rule {specialRule.RuleType} not available for {ModelType} model");
        }
        SpecialRules.Add(specialRule);

        if (ChampionModel != null)
        {
            ChampionModel.SpecialRules.Add(specialRule);
        }
    }

    public void SetMount(TowModelMount mount)
    {
        if (!AvailableMounts.Any(m => m.Item1 == mount.ModelMountType))
        {
            throw new Exception($"Mount {mount.ModelMountType} not available for {ModelType} model");
        }
        Mount = mount;

        if (ChampionModel != null)
        {
            ChampionModel.Mount = mount;
        }
    }

    public int UnitStrength()
    {
        switch (ModelTroopType)
        {
            case TowModelTroopType.RegularInfantry:
            case TowModelTroopType.RegularInfantryCharacter:
                return 1;
            case TowModelTroopType.MonstrousInfantry:
                return 3;
            case TowModelTroopType.LightCavalry:
                return 2;
            case TowModelTroopType.HeavyCavalry:
                return 2;
            case TowModelTroopType.MonstrousCavalry:
                return 3;
            case TowModelTroopType.MonstrousCreature: // as starting wounds
                return Wounds;
            case TowModelTroopType.WarMachine: // as starting wounds
                return Wounds;
            case TowModelTroopType.HeavyChariot:
                return 5;
            case TowModelTroopType.LightChariot:
                return 3;
            case TowModelTroopType.Behemoth: // as starting wounds
                return Wounds;
            case TowModelTroopType.WarBeast:
                return 1;
            case TowModelTroopType.Swarm:
                return 3;
            default:
                throw new Exception("Unknown model type");
        }
    }

    private void SetDefaultBaseSize()
    {
        switch (ModelTroopType)
        {
            case TowModelTroopType.RegularInfantry:
            case TowModelTroopType.RegularInfantryCharacter:
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
    RegularInfantryCharacter,
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

//public static class TowModelTroopTypeExtensions
//{
//    public static int UnitStrength(this TowModelTroopType troopType)
//    {
//        switch (troopType)
//        {
//            case TowModelTroopType.RegularInfantry:
//            case TowModelTroopType.RegularInfantryCharacter:
//                return 1;
//            case TowModelTroopType.MonstrousInfantry:
//                return 3;
//            case TowModelTroopType.LightCavalry:
//                return 2;
//            case TowModelTroopType.HeavyCavalry:
//                return 2;
//            case TowModelTroopType.MonstrousCavalry:
//                return 3;
//            case TowModelTroopType.MonstrousCreature: // as starting wounds
//                return 1;
//            case TowModelTroopType.WarMachine: // as starting wounds
//                return 1;
//            case TowModelTroopType.HeavyChariot:
//                return 5;
//            case TowModelTroopType.LightChariot:
//                return 3;
//            case TowModelTroopType.Behemoth: // as starting wounds
//                return 1;
//            case TowModelTroopType.WarBeast:
//                return 1;
//            case TowModelTroopType.Swarm:
//                return 3;
//            default:
//                throw new Exception("Unknown model type");
//        }
//    }
//}
