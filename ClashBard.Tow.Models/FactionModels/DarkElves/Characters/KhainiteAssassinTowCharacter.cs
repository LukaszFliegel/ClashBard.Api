using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.StaticData;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters;

public class KhainiteAssassinTowCharacter : TowCharacter
{
    private static int pointsCost = 80;

    public KhainiteAssassinTowCharacter(TowObject owner)
        :base(owner, DarkElfTowModelType.KhainiteAssassin, 5, 8, 7, 4, 3, 2, 7, 3, 8, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new DarkElvesTowFaction(), 25, 25,
            new TowMagicItemCategory[] { TowMagicItemCategory.MagicArmour, TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem },
            mayBuyMagicItemsUpToPoints: 50)
    {
        // special rules
        AssignSpecialRule(new EternalHatred());
        AssignSpecialRule(new HatredAllEnemies());
        AssignSpecialRule(new HiddenDarkElves());
        AssignSpecialRule(new ImmuneToPsychology());
        AssignSpecialRule(new Murderous());
        AssignSpecialRule(new StrikeFirst());
                
        // weapons
        AssignDefault(new ThrowingWeaponsTowWeapon(this));

        AvailableWeapons.Add((TowWeaponType.AdditionalHandWeapon, 3));
        AvailableWeapons.Add((TowWeaponType.RepeaterHandbow, 5));

        // armours

        // mounts
    }

    // code for Khainite Assassin specific rules

    public DarkElvesForbiddenPoisons? ForbiddenPoison { get; private set; }

    public void SetForbiddenPoison(DarkElvesForbiddenPoisons giftOfKhaine)
    {
        if (giftOfKhaine.Owner != this)
        {
            throw new ArgumentException("Gift of Khaine must belong to the same owner");
        }

        ForbiddenPoison = giftOfKhaine;
    }

    public override int CalculateTotalCost()
    {
        var giftOfKhainePoints = ForbiddenPoison?.Points ?? 0;

        return base.CalculateTotalCost() + giftOfKhainePoints;
    }

    public override ICollection<TowMagicItem> GetMagicItems()
    {
        var magicItems = base.GetMagicItems();
        if (ForbiddenPoison != null)
        {
            magicItems.Add(ForbiddenPoison);
        }
        return magicItems;
    }
}

public abstract class DarkElvesForbiddenPoisons : TowMagicItem
{
    public DarkElvesForbiddenPoisons(TowObject owner, TowDarkElfMagicItemType type, int points) : base(owner, type, points, TowMagicItemCategory.FactionSpecificPrintAsWeapon)
    {
    }
}

/*
Forbidden Poisons
Khainite Assassins coat their weapons with a variety of terrible and forbidden poisons.
As described above, a Khainite Assassin may take one of the following forbidden poisons:
•
Black Lotus: For each unsaved Wound inflicted upon them by this character, enemy characters suffer a -1 modifier to their Leadership characteristic for the remainder of the game.
•
Dark Venom: This character has the Killing Blow special rule.
•
Manbane: When this character makes a roll To Wound, a roll of 4+ is always a success, regardless of the target’s Toughness.
*/

public class BlackLotusForbiddenPoison : DarkElvesForbiddenPoisons
{
    public BlackLotusForbiddenPoison(TowObject owner) : base(owner, TowDarkElfMagicItemType.BlackLotus, 5)
    {
        AssignSpecialRule(new BlackLotusForbiddenPoisonRules());
    }
}

public class DarkVenomForbiddenPoison : DarkElvesForbiddenPoisons
{
    public DarkVenomForbiddenPoison(TowObject owner) : base(owner, TowDarkElfMagicItemType.DarkVenom, 15)
    {
        AssignSpecialRule(new KillingBlow());
    }
}

public class ManbaneForbiddenPoison : DarkElvesForbiddenPoisons
{
    public ManbaneForbiddenPoison(TowObject owner) : base(owner, TowDarkElfMagicItemType.Manbane, 15)
    {
        AssignSpecialRule(new ManbaneForbiddenPoisonRules());
    }
}