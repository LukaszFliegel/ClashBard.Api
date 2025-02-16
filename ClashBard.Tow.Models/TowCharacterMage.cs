﻿using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;

namespace ClashBard.Tow.Models;

public abstract class TowCharacterMage : TowCharacter, IMagicUser
{
    private TowMagicLevelType magicLevel;

    protected TowCharacterMage(TowObject owner, Enum modelType, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld, int pointCost,
        TowModelTroopType modelTroopType, TowFaction faction, int baseSizeWidth, int baseSizeLength, TowMagicLevelType magicLevel, TowMagicLoreType[] availableMagicLoreTypes,
        TowMagicItemCategory[]? availableMagicItemTypes = null, int minUnitSize = 1, int? maxUnitSize = 1, int mayBuyMagicItemsUpToPoints = 0) 
        : base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, pointCost, modelTroopType, faction, baseSizeWidth, baseSizeLength, 
            availableMagicItemTypes, minUnitSize, maxUnitSize, mayBuyMagicItemsUpToPoints)
    {
        this.magicLevel = magicLevel;
        AvailableMagicLoreTypes = availableMagicLoreTypes;
        AvailableMagicItemTypes.Add(TowMagicItemCategory.Arcane);
    }

    public int MagicLevel => (int)magicLevel;

    protected ICollection<(TowMagicLevelType, int)> AvailableMagicLevels { get; private set; } = new HashSet<(TowMagicLevelType, int)>() { }; // (magicLevel, costOfUpgrade)

    protected ICollection<TowMagicLoreType> AvailableMagicLoreTypes { get; set; } = new HashSet<TowMagicLoreType>() { };

    protected TowMagicLoreType? ChosenLore { get; set; } = null;

    public void SetMagicLore(TowMagicLoreType magicLore)
    {
        if (AvailableMagicLoreTypes.Contains(magicLore))
        {
            ChosenLore = magicLore;
        }
        else
        {
            throw new ArgumentException($"Magic lore {magicLore} not available for {ModelType.ToNameString()}");
        }
    }

    public TowMagicLoreType? GetMagicLore()
    {
        return ChosenLore;
    }

    public void SetMagicLevel(TowMagicLevelType magicLevel)
    {
        if (AvailableMagicLevels.Select(p => p.Item1).Contains(magicLevel))
        {
            this.magicLevel = magicLevel;
        }
        else
        {
            throw new ArgumentException($"Magic level {magicLevel} not available for {ModelType.ToNameString()}");
        }
    }

    public override IEnumerable<ValidationError> Validate()
    {
        if (_magicItems.Sum(p => p.Points) > MayBuyMagicItemsUpToPoints)
        {
            yield return new ValidationError($"{ModelType.ToNameString()} has exceeded the maximum magic item points allowance of {MayBuyMagicItemsUpToPoints}", ModelType.ToNameString());
        }

        if (ChosenLore == null)
        {
            yield return new ValidationError($"{ModelType.ToNameString()} must choose a magic lore", ModelType.ToNameString());
        }

        foreach (var error in base.Validate())
        {
            yield return error;
        }
    }

    public override int CalculateTotalCost()
    {
        int totalCost = base.CalculateTotalCost();

        foreach (var magicLevel in AvailableMagicLevels)
        {
            if (magicLevel.Item1 == this.magicLevel)
            {
                totalCost += magicLevel.Item2;
            }
        }

        return totalCost;
    }
}
