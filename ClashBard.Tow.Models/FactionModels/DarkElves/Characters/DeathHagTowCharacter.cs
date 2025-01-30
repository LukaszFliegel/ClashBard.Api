using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.Factions.MagiItems;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.StaticData;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters;

public class DeathHagTowCharacter : TowCharacter
{
    private static int pointsCost = 70;

    public DeathHagTowCharacter(TowObject owner)
        :base(owner, DarkElfTowModelType.DeathHag, 5, 6, 6, 4, 3, 2, 7, 3, 8, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new DarkElvesTowFaction(), 25, 25,
            new TowMagicItemCategory[] { TowMagicItemCategory.MagicArmour, TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem },
            mayBuyMagicItemsUpToPoints: 75)
    {
        // special rules
        AssignSpecialRule(new EternalHatred());
        AssignSpecialRule(new Frenzy());
        AssignSpecialRule(new HatredAllEnemies());
        AssignSpecialRule(new Loner());
        AssignSpecialRule(new Murderous());
        AssignSpecialRule(new PoisonedAttacks());
        AssignSpecialRule(new StrikeFirst());
                
        // weapons
        AssignDefault(new AdditionalHandWeaponTowWeapon(this));

        // armours
        AvailableArmours.Add((TowArmourType.HeavyArmour, 3));
        AvailableArmours.Add((TowArmourType.FullPlateArmour, 6));
        AvailableArmours.Add((TowArmourType.Shield, 2));

        // mounts
        AvailableMounts.Add((DarkElfTowModelMountType.CauldronOfBlood, 150));

        // model specifics
        //AvailableMagicItemTypes.Add(TowMagicItemCategory.DarkElfSpecific);
    }

    // code for Death Hag specific rules

    public DarkElvesGiftsOfKhaine? GiftOfKhaine { get; private set; }

    public void SetGiftOfKhaine(DarkElvesGiftsOfKhaine giftOfKhaine)
    {
        if (giftOfKhaine.Owner != this)
        {
            throw new ArgumentException("Gift of Khaine must belong to the same owner");
        }

        GiftOfKhaine = giftOfKhaine;
    }

    public override int CalculateTotalCost()
    {
        var giftOfKhainePoints = GiftOfKhaine?.Points ?? 0;

        return base.CalculateTotalCost() + giftOfKhainePoints;
    }

    public override ICollection<TowMagicItem> GetMagicItems()
    {
        // return base.GetMagicItems() and GiftOfKhaine
        var magicItems = base.GetMagicItems();
        if (GiftOfKhaine != null)
        {
            magicItems.Add(GiftOfKhaine);
        }
        return magicItems;
    }
}

public abstract class DarkElvesGiftsOfKhaine : TowMagicItem
{
    public DarkElvesGiftsOfKhaine(TowObject owner, TowDarkElfMagicItemType type, int points) : base(owner, type, points, TowMagicItemCategory.FactionSpecificPrintAsWeapon)
    {
    }
}

/*
Gifts Of Khaine
Blessed by Khaine, a Death Hag and her minions are a fearful sight to behold.
As described above, a Death Hag may take one of the following gifts of Khaine:
•
Cry of War: Enemy units suffer a -1 modifier to their Leadership characteristic whilst within the Command range of one or more Death Hags that have this special rule and that are not fleeing.
•
Rune of Khaine: This character has the Extra Attacks (+D3) special rule.
•
Witchbrew: This character, their mount and any unit they have joined cannot lose the Frenzy special rule.
*/

public class CryOfWarRuneOfKhaine : DarkElvesGiftsOfKhaine
{
    public CryOfWarRuneOfKhaine(TowObject owner) : base(owner, TowDarkElfMagicItemType.CryOfWar, 15)
    {
        AssignSpecialRule(new CryOfWar());
    }
}

public class RuneOfKhaineRuneOfKhaine : DarkElvesGiftsOfKhaine
{
    public RuneOfKhaineRuneOfKhaine(TowObject owner) : base(owner, TowDarkElfMagicItemType.RuneOfKhaine, 10)
    {
        AssignSpecialRule(new ExtraAttacksPlusD3());
    }
}

public class WitchbrewRuneOfKhaine : DarkElvesGiftsOfKhaine
{
    public WitchbrewRuneOfKhaine(TowObject owner) : base(owner, TowDarkElfMagicItemType.Witchbrew, 20)
    {
        AssignSpecialRule(new Witchbrew());
    }
}