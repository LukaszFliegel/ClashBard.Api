using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.StaticData;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ClashBard.Tow.Models;

public class TowModel: TowObjectWithSpecialRules, ISavesBearer, ISaveImprover
{   
    public TowModel(TowObject owner, Enum modelType, int? m, int? ws, int? bs, int? s, int t, int w, int? i, int? a, int? ld, int pointCost, TowModelTroopType modelTroopType/*, TowModelSlotType modelSlotType*/, TowFaction faction,
        int minUnitSize = 1, int? maxUnitSize = null, int? armorValue = null)
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
        PointCost = pointCost;
        ModelTroopType = modelTroopType;
        //ModelSlotType = modelSlotType;
        Faction = faction;
        SetDefaultBaseSize();
        MinUnitSize = minUnitSize;
        MaxUnitSize = maxUnitSize;
        this.armorValue = armorValue;

        // add default hand weapon
        AvailableWeapons.Add((TowWeaponType.HandWeapon, 0));
        Assign(new HandWeaponTowWeapon(this));

        if(this is ISaveImprover saveImprover)
        {
            SaveImprovers.Add(saveImprover);
        }

        if (this is IWardSaveImprover wardSaveImprover)
        {
            WardSaveImprovers.Add(wardSaveImprover);
        }
    }

    public TowModel(TowObject owner, Enum modelType, int? m, int? ws, int? bs, int? s, int t, int w, int? i, int? a, int? ld, int pointCost, TowModelTroopType modelTroopType/*, TowModelSlotType modelSlotType*/, TowFaction faction, 
        int? baseSizeWidth, int? baseSizeLength, 
        int minUnitSize = 1, int? maxUnitSize = null, int? armorValue = null)
        : this(owner, modelType, m, ws, bs, s, t, w, i, a, ld, pointCost, modelTroopType/*, modelSlotType*/, faction, minUnitSize, maxUnitSize, armorValue)
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

    private int? armorValue { get; set; }

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
        if (ChampionModel != null)
        {
            ChampionModel.ChampionName = championName;
            ChampionModel.PointCost = championUpgradeCost.Value;
        }
        ChampionMagicItemsUpToPoints = championMagicItemsUpToPoints;

        StandardBearerUpgradeCost = standardBearerUpgradeCost;

        MusicianUpgradeCost = musicianUpgradeCost;
        MagicStandardUpToPoints = magicStandardUpToPoints;
        
    }    

    public int? BaseSizeWidth { get; set; }
    public int? BaseSizeLength { get; set; }

    public ICollection<(TowWeaponType, int)> AvailableWeapons { get; protected set; } = new HashSet<(TowWeaponType, int)>() { };
    public ICollection<TowOption<TowWeaponType>> OptionalWeapons { get; protected set; } = new List<TowOption<TowWeaponType>>() { };
    private ICollection<TowWeapon> Weapons { get; set; } = new List<TowWeapon>() { };

    public ICollection<TowWeapon> GetWeapons(bool excludeHandWeapon = true)
    {
        return Weapons.Where(p => excludeHandWeapon ? p.WeaponType != TowWeaponType.HandWeapon : true).ToImmutableList();
    }

    public ICollection<(TowArmourType, int)> AvailableArmours { get; protected set; } = new HashSet<(TowArmourType, int)>() { };   
    private ICollection<TowArmour> Armours { get; set; } = new List<TowArmour>() { };

    public ICollection<TowArmour> GetArmours()
    {
        return Armours.ToImmutableList();
    }

    public void Assign(TowArmour armour)
    {
        if (!AvailableArmours.Select(p => p.Item1).Contains(armour.ArmorType))
        {
            throw new Exception($"Armor {armour.ArmorType} not available for {ModelType} model");
        }

        SaveImprovers.Add(armour);
        WardSaveImprovers.Add(armour);

        Armours.Add(armour);
    }

    public void AssignDefault(TowArmour armour)
    {
        if (!AvailableArmours.Select(p => p.Item1).Contains(armour.ArmorType))
        {
            AvailableArmours.Add((armour.ArmorType, 0));
        }

        SaveImprovers.Add(armour);
        WardSaveImprovers.Add(armour);

        Armours.Add(armour);
    }

    // overloaded function to assign armor (@see Assign(TowArmourType ArmorType))
    //public void Assign(TowArmourType ArmorType)
    //{
    //    if (!AvailableArmours.Select(p => p.Item1).Contains(ArmorType))
    //    {
    //        throw new Exception($"Armor {ArmorType} not available for {ModelType} model");
    //    }

    //    var armour = (TowArmour)Activator.CreateInstance(Type.GetType($"ClashBard.Tow.Models.Armors.{ArmorType}TowArmour"), this);

    //    Assign(armour);
    //}

    public void Assign(TowWeapon weapon)
    {
        if(!AvailableWeapons.Select(p => p.Item1).Contains(weapon.WeaponType))
        {
            throw new Exception($"Weapon {weapon.WeaponType} not available for {ModelType} model");
        }

        if (weapon is ISaveImprover saveImprover)
        {
            SaveImprovers.Add(saveImprover);
        }

        if (weapon is IWardSaveImprover wardSaveImprover)
        {
            WardSaveImprovers.Add(wardSaveImprover);
        }

        Weapons.Add(weapon);
    }

    public void AssignDefault(TowWeapon weapon)
    {
        if (!AvailableWeapons.Select(p => p.Item1).Contains(weapon.WeaponType))
        {
            AvailableWeapons.Add((weapon.WeaponType, 0));
        }

        if (weapon is ISaveImprover saveImprover)
        {
            SaveImprovers.Add(saveImprover);
        }

        if (weapon is IWardSaveImprover wardSaveImprover)
        {
            WardSaveImprovers.Add(wardSaveImprover);
        }

        Weapons.Add(weapon);
    }

    // overloaded function to assign weapon (@see Assign(TowWeaponType weaponType))
    //public void Assign(TowWeaponType weaponType)
    //{
    //    if (!AvailableWeapons.Select(p => p.Item1).Contains(weaponType))
    //    {
    //        throw new Exception($"Weapon {weaponType} not available for {ModelType} model");
    //    }

    //    var weapon = (TowWeapon)Activator.CreateInstance(Type.GetType($"ClashBard.Tow.Models.Weapons.{weaponType}TowWeapon"), this);

    //    Assign(weapon);
    //}

    public TowModelTroopType ModelTroopType { get; set; }
    public int MinUnitSize { get; set; }
    public int? MaxUnitSize { get; set; }

    public TowModelMount? Mount { get; private set; }

    public ICollection<(TowModelMountType, int)> AvailableMounts { get; protected set; } = new HashSet<(TowModelMountType, int)>() { };

    public ICollection<TowModelAdditional> Crew { get; set; } = new HashSet<TowModelAdditional>();


    public TowFaction Faction { get; set; }

    public ICollection<(TowSpecialRuleType, int)> AvailableSpecialRules { get; set; } = new HashSet<(TowSpecialRuleType, int)>() { };

    public ICollection<TowMagicItem> MagicItems { get; set; } = new HashSet<TowMagicItem>();

    public ICollection<IWardSaveImprover> WardSaveImprovers { get; set; } = new HashSet<IWardSaveImprover>();

    public ICollection<ISaveImprover> SaveImprovers { get; set; } = new HashSet<ISaveImprover>();

    public int? MeleeSaveBaseline => armorValue;

    public int MeleeSaveImprovement => 0;

    public int? RangedSaveBaseline => armorValue;

    public int RangedSaveImprovement => 0;

    public bool AsteriskOnSave => false;

    void ISavesBearer.RegisterWardSaveImprover(IWardSaveImprover wardSaveImprover)
    {
        WardSaveImprovers.Add(wardSaveImprover);
    }

    void ISavesBearer.RegisterSaveImprover(ISaveImprover saveImprover)
    {
        SaveImprovers.Add(saveImprover);
    }

    public string GetSaveString()
    {
        var saveBearer = this as ISavesBearer;

        if (saveBearer.GetMeleeSave().HasValue)
        {
            if (saveBearer.GetRangedSave().HasValue && saveBearer.GetMeleeSave() != saveBearer.GetRangedSave())
                return $"{saveBearer.GetMeleeSave()}/{saveBearer.GetRangedSave()}{PrintAsteriskfNeededForSave()}";
            else
                return $"{saveBearer.GetMeleeSave()}{PrintAsteriskfNeededForSave()}";
        }
        else
            return string.Empty;
    }

    public string GetWardSaveString()
    {
        var saveBearer = this as ISavesBearer;

        if (saveBearer.GetMeleeWardSave().HasValue)
        {
            if (saveBearer.GetRangedWardSave().HasValue && saveBearer.GetMeleeWardSave() != saveBearer.GetRangedWardSave())
                return $"{saveBearer.GetMeleeWardSave()}/{saveBearer.GetRangedWardSave()}{PrintAsteriskfNeededForWardSave()}";
            else
                return $"{saveBearer.GetMeleeWardSave()}{PrintAsteriskfNeededForWardSave()}";
        }
        else
            return string.Empty;
    }

    private string PrintAsteriskfNeededForSave()
    {
        if (SaveImprovers.Any(p => p.AsteriskOnSave))
        {
            return "*";
        }

        return string.Empty;
    }

    private string PrintAsteriskfNeededForWardSave()
    {
        if(WardSaveImprovers.Any(a => a.AsteriskOnWardSave))
        {
            return "*";
        }

        return string.Empty;
    }

    public void SetWeapon(TowWeapon weapon)
    {
        //if(weapon.Owner != this && weapon.Owner != Owner) // TODO: how to validate, that the owner of a weapon is the model?
        //{
        //    throw new ArgumentException("Weapon must belong to the same owner");
        //}

        if (!AvailableWeapons.Any(w => w.Item1 == weapon.WeaponType))
        {
            throw new ArgumentException($"Weapon {weapon.WeaponType} not available for {ModelType} model");
        }

        Assign(weapon);

        if (ChampionModel != null)
        {
            ChampionModel.Assign(weapon);
        }
    }

    public void SetArmor(TowArmour armor)
    {
        //if (armor.Owner != this && armor.Owner != Owner)
        //{
        //    throw new ArgumentException("Armor must belong to the same owner");
        //}

        if (!AvailableArmours.Any(a => a.Item1 == armor.ArmorType))
        {
            throw new ArgumentException($"Armor {armor.ArmorType} not available for {ModelType} model");
        }
        Assign(armor);

        if(ChampionModel != null)
        {
            ChampionModel.Assign(armor);
        }
    }

    public void SetSpecialRule(TowSpecialRule specialRule)
    {
        if (!AvailableSpecialRules.Any(sr => sr.Item1 == specialRule.RuleType))
        {
            throw new ArgumentException($"Special rule {specialRule.RuleType} not available for {ModelType} model");
        }
        SpecialRules.Add(specialRule);

        if (ChampionModel != null)
        {
            ChampionModel.SpecialRules.Add(specialRule);
        }
    }

    public void Assign(TowModelMount mount)
    {
        //if (mount.Owner != this && mount.Owner != Owner)
        //{
        //    throw new ArgumentException("Mount must belong to the same owner");
        //}

        if (!AvailableMounts.Any(m => m.Item1 == mount.ModelMountType))
        {
            throw new ArgumentException($"Mount {mount.ModelMountType} not available for {ModelType} model");
        }

        if (mount is ISaveImprover saveImprover)
        {
            SaveImprovers.Add(saveImprover);
        }

        if (mount is IWardSaveImprover wardSaveImprover)
        {
            WardSaveImprovers.Add(wardSaveImprover);
        }

        Mount = mount;

        if (ChampionModel != null)
        {
            ChampionModel.Mount = mount;
        }
    }

    public void AssignDefault(TowModelMount mount)
    {
        if (!AvailableMounts.Any(m => m.Item1 == mount.ModelMountType))
        {
            AvailableMounts.Add((mount.ModelMountType, 0));
        }

        if (mount is ISaveImprover saveImprover)
        {
            SaveImprovers.Add(saveImprover);
        }

        if (mount is IWardSaveImprover wardSaveImprover)
        {
            WardSaveImprovers.Add(wardSaveImprover);
        }

        Mount = mount;

        if (ChampionModel != null)
        {
            ChampionModel.Assign(mount);
        }
    }

    public override IEnumerable<ValidationError> Validate()
    {
        Console.WriteLine($"Validate of {ModelType.ToNameString()}");
        // check if there is a weapon of type cavarly spear or lance and there is no mount assigned
        if (Weapons.Any(w => w.WeaponType == TowWeaponType.CavalrySpear || w.WeaponType == TowWeaponType.Lance) && Mount == null)
        {
            yield return new ValidationError("Cavalry spear or lance requires a mount", ModelType.ToNameString());
        }

        foreach (var error in base.Validate())
        {
            yield return error;
        }
    }

    internal bool IsScout()
    {
        return SpecialRules.Any(rule => rule is IScouts);
    }

    internal bool IsVanguard()
    {
        return SpecialRules.Any(rule => rule is IVanguard);
    }

    internal bool IsAmbusher()
    {
        return SpecialRules.Any(rule => rule is IAmbushers);
    }

    //public int UnitStrength()
    //{
    //    switch (ModelTroopType)
    //    {
    //        case TowModelTroopType.RegularInfantry:
    //        case TowModelTroopType.RegularInfantryCharacter:
    //            return 1;
    //        case TowModelTroopType.MonstrousInfantry:
    //            return 3;
    //        case TowModelTroopType.LightCavalry:
    //            return 2;
    //        case TowModelTroopType.HeavyCavalry:
    //            return 2;
    //        case TowModelTroopType.MonstrousCavalry:
    //            return 3;
    //        case TowModelTroopType.MonstrousCreature: // as starting wounds
    //            return Wounds;
    //        case TowModelTroopType.WarMachine: // as starting wounds
    //            return Wounds;
    //        case TowModelTroopType.HeavyChariot:
    //            return 5;
    //        case TowModelTroopType.LightChariot:
    //            return 3;
    //        case TowModelTroopType.Behemoth: // as starting wounds
    //            return Wounds;
    //        case TowModelTroopType.WarBeast:
    //            return 1;
    //        case TowModelTroopType.Swarm:
    //            return 3;
    //        default:
    //            throw new Exception("Unknown model type");
    //    }
    //}

    public int UnitStrength()
    {
        var modelTroopType = Mount != null ? Mount.ModelTroopType : ModelTroopType;

        switch (modelTroopType)
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
                return CalculateTotalWounds();
            case TowModelTroopType.WarMachine: // as starting wounds
                return CalculateTotalWounds();
            case TowModelTroopType.HeavyChariot:
                return 5;
            case TowModelTroopType.LightChariot:
                return 3;
            case TowModelTroopType.Behemoth: // as starting wounds
                return CalculateTotalWounds();
            case TowModelTroopType.WarBeast:
                return 1;
            case TowModelTroopType.Swarm:
                return 3;
            default:
                throw new Exception("Unknown model type");
        }
    }

    public int CalculateTotalWounds()
    {
        if (Mount != null)
            return Wounds + Mount.WoundsAdded ?? 0;

        return Wounds;
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
