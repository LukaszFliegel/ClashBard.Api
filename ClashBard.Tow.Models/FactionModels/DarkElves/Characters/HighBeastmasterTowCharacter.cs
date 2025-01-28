using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;
using ClashBard.Tow.StaticData;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters;

public class HighBeastmasterTowCharacter : TowCharacter
{
    private static int pointsCost = 75;

    public HighBeastmasterTowCharacter(TowObject owner)
        :base(owner, DarkElfTowModelType.HighBeastmaster, null, 7, 7, 4, 3, 3, 5, 3, 9, pointsCost,
            TowModelTroopType.RegularInfantryCharacter, new DarkElvesTowFaction(), null, null,
            new TowMagicItemCategory[] { TowMagicItemCategory.MagicArmour, TowMagicItemCategory.MagicWeapon, TowMagicItemCategory.Talisman, TowMagicItemCategory.EnchantedItem },
            mayBuyMagicItemsUpToPoints: 75)
    {
        // special rules
        AssignSpecialRule(new EternalHatred());
        AssignSpecialRule(new GoadBeast());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new Murderous());
        AssignSpecialRule(new StrikeFirst());

        AvailableSpecialRules.Add((TowSpecialRuleType.SeaDragonCloak, 4));

        // weapons
        AvailableWeapons.Add((TowWeaponType.CavalrySpear, 2));
        AvailableWeapons.Add((TowWeaponType.RepeaterCrossbow, 6));        

        // armours
        AssignDefault(new LightArmourTowArmour(this));

        AvailableArmours.Add((TowArmourType.HeavyArmour, 3));
        AvailableArmours.Add((TowArmourType.Shield, 2));

        // mounts
        AvailableMounts.Add((TowModelMountType.ScourgerunnerChariot, 85));
        AvailableMounts.Add((TowModelMountType.Manticore, 130));
    }

    public override IEnumerable<ValidationError> Validate()
    {
        Console.WriteLine("HB 1");
        if (Mount == null)
            yield return new ValidationError("Mount is required for High Beastmaster", DarkElfTowModelType.HighBeastmaster.ToNameString());

        Console.WriteLine("HB 2");
        foreach (var error in base.Validate())
        {
            yield return error;
        }
        Console.WriteLine("HB 3");
    }
}
