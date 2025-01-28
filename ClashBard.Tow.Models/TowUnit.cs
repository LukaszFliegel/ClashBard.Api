using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.StaticData;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace ClashBard.Tow.Models;

public class TowUnit: TowObject, IMagicStandardUser
{
    public readonly TowModel Model;
    private readonly int amount;
    private readonly TowFaction faction;
    private readonly bool standard;
    private readonly bool musician;
    private readonly bool champion;

    public TowMagicStandard? MagicStandard { get; private set; }

    public int MagicStandardUpToPoints => Model.MagicStandardUpToPoints ?? 0;

    public TowUnit(TowModel model, int amount, TowFaction faction, bool standard = false, bool musician = false, bool champion = false)
    {
        Model = model;
        this.amount = amount;
        this.faction = faction;
        this.standard = standard;
        this.musician = musician;
        this.champion = champion;

        if(standard && !Model.StandardBearerUpgradeCost.HasValue)
            throw new ArgumentException($"{Model.ModelType} does not have standard bearer upgrade");

        if (musician && !Model.MusicianUpgradeCost.HasValue)
            throw new ArgumentException($"{Model.ModelType} does not have musician upgrade");

        if (champion && !Model.ChampionUpgradeCost.HasValue)
            throw new ArgumentException($"{Model.ModelType} does not have champion upgrade");
    }
    
    public string GetRulesShortDescription()
    {
        StringBuilder shortDescriptionSb = new();
        string separator = ClashBardStatic.Separator;

        //foreach (var weapon in Model.GetWeapons().Where(p => p.WeaponType != TowWeaponType.HandWeapon))
        //{
        //    shortDescriptionSb.Append(weapon.WeaponType.ToDescriptionString() + ": ");
        //    shortDescriptionSb.Append(weapon.GetSpecialRulesShortDescription() + separator);
        //}

        //shortDescriptionSb.AppendLine();

        // for printing take armour with highest MeleeSaveBaseline and all armours that have any improvement
        List<TowArmour> armoursToPrint = new();
        
        if(Model.GetArmours().Any(p => p.MeleeSaveBaseline > 0))
            armoursToPrint.Add(Model.GetArmours().Where(p => p.MeleeSaveBaseline > 0).OrderBy(p => p.MeleeSaveBaseline).First());

        armoursToPrint.AddRange(Model.GetArmours().Where(p => 
            p.MeleeSaveImprovement > 0
            || p.RangedSaveImprovement > 0
            || p.MeleeWardSaveImprovement > 0
            || p.RangedWardSaveImprovement > 0
            ));

        bool atLeastOneArmorPrinted = false;
        foreach (var armor in armoursToPrint)
        {
            shortDescriptionSb.Append(armor.ArmorType.ToNameString() + separator);
            atLeastOneArmorPrinted = true;
        }

        if(atLeastOneArmorPrinted)
            shortDescriptionSb.AppendLine();

        foreach (var rule in Model.GetSpecialRules().Where(p => p.PrintInSummary))
        {
            shortDescriptionSb.Append(rule.GetShortDescription() + separator);
        }

        if(standard)
        {
            shortDescriptionSb.Append($"Standard: +1 CR" + separator);
        }

        if (musician)
        {
            shortDescriptionSb.Append($"Musician: +1 Ld to rally, +1 CR on tie, +1 Ld on march test" + separator);
        }
       
        return shortDescriptionSb.ToString().TrimEnd(separator.ToCharArray());
    }

    public void SetMagicStandard(TowMagicStandard magicStandard)
    {
        if (magicStandard.Points > Model.MagicStandardUpToPoints)
            throw new ArgumentException($"{magicStandard.MagicItemType} cost exceeds available {Model.MagicStandardUpToPoints} for {Model.ModelType}");

        MagicStandard = magicStandard;
    }

    public void SetWeapon(TowWeapon weapon)
    {
        Model.SetWeapon(weapon);
    }

    //public void SetMagicWeapon(TowMagicWeapon magicWeapon)
    //{
    //    Model.SetMagicWeapon(magicWeapon);
    //}

    public void SetArmor(TowArmour armor)
    {
        Model.SetArmor(armor);
    }

    public void SetSpecialRule(TowSpecialRule specialRule)
    {
        Model.SetSpecialRule(specialRule);
    }

    public int GetAmount()
    {
        return amount;
    }

    public bool HasStandard()
    {
        return standard;
    }
    public bool HasMusician()
    {
        return musician;
    }
    public bool HasChampion()
    {
        return champion;
    }

    public bool HasMagicBanner()
    {
        return MagicStandard != null;
    }

    public TowMagicStandard GetMagicStandard()
    {
        if (MagicStandard == null)
            throw new Exception($"Magic banner not available for {Model.ModelType}");

        return MagicStandard;
    }

    public int UnitStrength()
    {
        if (Model.Mount != null)
            return Model.Mount.UnitStrength() * GetAmount();
        else
            return Model.UnitStrength() * GetAmount();
    }

    public int CalculateTotalCost()
    {
        var cost = Model.PointCost * GetAmount();

        if (HasStandard())
            cost += Model.StandardBearerUpgradeCost.Value;

        if (HasMusician())
            cost += Model.MusicianUpgradeCost.Value;

        if (HasChampion())
            cost += Model.ChampionUpgradeCost.Value;

        if (MagicStandard != null)
            cost += MagicStandard.Points;

        // if any of available weapons is assign to Weapons in a model, then add this available weapon cost
        foreach (var availableWeapon in Model.AvailableWeapons)
        {
            if(Model.GetWeapons().Any(p => p.WeaponType == availableWeapon.Item1))
                cost += availableWeapon.Item2 * GetAmount();
        }

        // if any available armor is assign to Armors in a model, also add its cost
        foreach (var availableArmor in Model.AvailableArmours)
        {
            if (Model.GetArmours().Any(p => p.ArmorType == availableArmor.Item1))
                cost += availableArmor.Item2 * GetAmount();
        }

        return cost;
    }

}
