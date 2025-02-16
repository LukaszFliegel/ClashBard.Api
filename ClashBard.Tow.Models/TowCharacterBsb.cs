﻿using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models;

public class TowCharacterBsb : TowCharacter, IMagicStandardUser
{
    private readonly int magicStandardUpToPoints;
    private readonly int battleStandardBearerUpgradeCost;

    //private TowMagicStandard? magicStandard;

    private bool isBattleStandardBearer = false;    

    public TowCharacterBsb(TowObject owner, Enum modelType, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld, int pointCost,
        TowModelTroopType modelTroopType, TowFaction faction, int baseSizeWidth, int baseSizeLength, 
        int magicStandardUpToPoints, int battleStandardBearerUpgradeCost,
        TowMagicItemCategory[]? availableMagicItemTypes = null, int minUnitSize = 1, int? maxUnitSize = 1, int mayBuyMagicItemsUpToPoints = 0) 
        : base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, pointCost, modelTroopType, faction, baseSizeWidth, baseSizeLength, 
            availableMagicItemTypes, minUnitSize, maxUnitSize, mayBuyMagicItemsUpToPoints)
    {
        this.magicStandardUpToPoints = magicStandardUpToPoints;
        this.battleStandardBearerUpgradeCost = battleStandardBearerUpgradeCost;
        AvailableMagicItemTypes.Add(TowMagicItemCategory.MagicStandard);
    }

    public TowMagicStandard? MagicStandard => _magicItems.Where(p => p.TowMagicItemCategory == TowMagicItemCategory.MagicStandard).Select(p => p as TowMagicStandard).FirstOrDefault();

    int IMagicStandardUser.MagicStandardUpToPoints => magicStandardUpToPoints;

    public void SetMagicStandard(TowMagicStandard magicStandard)
    {
        if (magicStandard.Points > MagicStandardUpToPoints)
            throw new ArgumentException($"{magicStandard.MagicItemType} cost exceeds available {MagicStandardUpToPoints} for {GetType().Name}");

        if (AvailableMagicItemTypes.Contains(TowMagicItemCategory.MagicStandard))
        {
            _magicItems.Add(magicStandard);
        }
    }

    internal void SetAsArmyBattleStandardBearer(bool isBattleStandardBearer)
    {
        // if it was BSB but no longer should be, remove the magic standard
        if (this.isBattleStandardBearer && !isBattleStandardBearer && MagicStandard != null)
        {
            _magicItems.Remove(MagicStandard);
        }

        this.isBattleStandardBearer = isBattleStandardBearer;
    }

    public override int CalculateTotalCost()
    {
        if(isBattleStandardBearer)
        {
            return base.CalculateTotalCost() + battleStandardBearerUpgradeCost;
        }

        return base.CalculateTotalCost();
    }
}
