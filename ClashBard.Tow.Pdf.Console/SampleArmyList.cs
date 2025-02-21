using ClashBard.Tow.Models;
using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.FactionModels.DarkElves;
using ClashBard.Tow.Models.FactionModels.DarkElves.Characters;
using ClashBard.Tow.Models.FactionModels.DarkElves.Characters.Mounts;
using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.Factions.ArmyCompositions;
using ClashBard.Tow.Models.MagicItems.ArcaneItems;
using ClashBard.Tow.Models.MagicItems.DarkElves.ArcaneItems;
using ClashBard.Tow.Models.MagicItems.DarkElves.Talismans;
using ClashBard.Tow.Models.MagicItems.EnchantedItems;
using ClashBard.Tow.Models.MagicItems.MagicBanners;
using ClashBard.Tow.Models.MagicItems.MagicWeapons;
using ClashBard.Tow.Models.MagicItems.Talismans;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Pdf.Console;

public class SampleArmyList
{
    public SampleArmyList()
    {

    }

    public TowArmy GetVnDarkElfArmy()
    {
        TowFaction faction = new DarkElvesTowFaction();

        TowArmy army = new(faction, 2000, "Dark Elves default");

        army.SetArmyComposition(new DarkElvesArmyComposition(army));

        var supremeSorceress = new SupremeSorceressTowCharacter(army);
        supremeSorceress.SetMount(new BlackDragonTowCharacterMount(supremeSorceress));
        supremeSorceress.SetMagicItem(new LoreFamiliarTowArcaneItem(supremeSorceress));
        supremeSorceress.SetMagicItem(new PendantOfKhaelethTowTalisman(supremeSorceress));
        supremeSorceress.SetMagicLore(TowMagicLoreType.Daemonology);

        var secondSupremeSorceress = new SupremeSorceressTowCharacter(army);
        secondSupremeSorceress.SetMagicLevel(TowMagicLevelType.Level4);
        secondSupremeSorceress.SetMount(new DarkPegasusTowCharacterMount(secondSupremeSorceress));
        secondSupremeSorceress.SetMagicLore(TowMagicLoreType.Illusion);

        secondSupremeSorceress.SetMagicItem(new TomeOfFurionTowArcaneItem(secondSupremeSorceress));
        secondSupremeSorceress.SetMagicItem(new FocusFamiliarTowArcaneItem(secondSupremeSorceress, 7));

        var deathHag = new DeathHagTowCharacter(army);
        deathHag.SetMagicItem(new RuneOfKhaineRuneOfKhaine(deathHag));
        deathHag.SetMagicItem(new OgreBladeTowMagicWeapon(deathHag));


        army.AddCharacter(supremeSorceress);
        army.AddCharacter(secondSupremeSorceress);
        army.AddCharacter(deathHag);

        var witchElves = new TowUnit(
            new WitchElfTowModel(army), 20, faction, true, true, true
            );
        witchElves.SetMagicStandard(new BannerOfHarGanethTowMagicBanner(witchElves));

        var darkRiders = new TowUnit(
            new DarkRiderTowModel(army), 6, faction, false, false, false
            );
        darkRiders.SetWeapon(new RepeaterCrossbowTowWeapon(darkRiders));
        darkRiders.SetArmor(new ShieldTowArmour(darkRiders));

        var darkRiders2 = new TowUnit(
            new DarkRiderTowModel(army), 6, faction, false, true, false
            );
        darkRiders2.SetWeapon(new RepeaterCrossbowTowWeapon(darkRiders2));
        darkRiders2.SetArmor(new ShieldTowArmour(darkRiders2));

        var coldOneKnights = new TowUnit(
            new ColdOneKnightTowModel(army), 7, faction, true, true, true
            );
        coldOneKnights.SetArmor(new FullPlateArmourTowArmour(coldOneKnights));
        coldOneKnights.SetMagicStandard(new WarBannerTowMagicBanner(coldOneKnights));

        var harpies = new TowUnit(
            new HarpyTowModel(army), 6, faction, false, false, false
            );

        var kharibdyss = new TowUnit(
            new KharibdyssTowModel(army), 1, faction, false, false, false
            );

        army.AddUnit(witchElves);
        army.AddUnit(darkRiders);
        army.AddUnit(darkRiders2);
        army.AddUnit(coldOneKnights);
        army.AddUnit(harpies);
        army.AddUnit(kharibdyss);

        return army;
    }

    public TowArmy GetVnDarkElfArmy2()
    {
        TowFaction faction = new DarkElvesTowFaction();

        TowArmy army = new(faction, 1500, "Dark Elves default");

        army.SetArmyComposition(new DarkElvesArmyComposition(army));

        var supremeSorceress = new SupremeSorceressTowCharacter(army);
        supremeSorceress.SetMagicLevel(TowMagicLevelType.Level4);
        supremeSorceress.SetMagicLore(TowMagicLoreType.Illusion);
        supremeSorceress.SetMount(new DarkSteedTowCharacterMount(supremeSorceress));
        supremeSorceress.SetMagicItem(new TomeOfFurionTowArcaneItem(supremeSorceress));
        supremeSorceress.SetMagicItem(new RubyRingOfRuinTowEnchantedItem(supremeSorceress));
        supremeSorceress.SetMagicItem(new FocusFamiliarTowArcaneItem(supremeSorceress, 4));        

        var sorceress = new SorceressTowCharacter(army);
        sorceress.SetMagicLevel(TowMagicLevelType.Level2);
        sorceress.SetMagicLore(TowMagicLoreType.BattleMagic);
        sorceress.SetMount(new DarkSteedTowCharacterMount(sorceress));

        var general = new DarkElfMasterTowCharacter(army);
        general.SetMagicItem(new SwordOfMightTowMagicWeapon(general));
        general.SetMagicItem(new TalismanOfProtectionTowTalisman(general));
        general.SetArmor(new FullPlateArmourTowArmour(general));
        general.SetArmor(new ShieldTowArmour(general));
        general.SetMount(new ColdOneTowCharacterMount(general));

        var bsb = new DarkElfMasterTowCharacter(army);
        army.BattleStandardBearer = bsb;
        bsb.SetMagicStandard(new BannerOfHarGanethTowMagicBanner(bsb));
        bsb.SetMagicItem(new PendantOfKhaelethTowTalisman(bsb));
        bsb.SetArmor(new FullPlateArmourTowArmour(bsb));
        bsb.SetArmor(new ShieldTowArmour(bsb));
        bsb.SetMount(new ColdOneTowCharacterMount(bsb));
        bsb.SetWeapon(new LanceTowWeapon(bsb));

        army.AddCharacter(supremeSorceress);
        army.AddCharacter(sorceress);
        army.AddCharacter(general);
        army.AddCharacter(bsb);

        var darkRiders = new TowUnit(
            new DarkRiderTowModel(army), 6, faction, false, true, true
            );
        darkRiders.SetWeapon(new RepeaterCrossbowTowWeapon(darkRiders));
        darkRiders.SetArmor(new ShieldTowArmour(darkRiders));

        var darkRiders2 = new TowUnit(
            new DarkRiderTowModel(army), 6, faction, false, true, true
            );
        darkRiders2.SetWeapon(new RepeaterCrossbowTowWeapon(darkRiders2));
        darkRiders2.SetArmor(new ShieldTowArmour(darkRiders2));

        var darkRiders3 = new TowUnit(
            new DarkRiderTowModel(army), 6, faction, false, true, true
            );
        darkRiders3.SetWeapon(new RepeaterCrossbowTowWeapon(darkRiders3));
        darkRiders3.SetArmor(new ShieldTowArmour(darkRiders3));


        var coldOneKnights = new TowUnit(
            new ColdOneKnightTowModel(army), 9, faction, true, false, true
            );
        coldOneKnights.SetArmor(new FullPlateArmourTowArmour(coldOneKnights));
        coldOneKnights.SetMagicStandard(new ColdBloodedBannerTowMagicBanner(coldOneKnights));


        army.AddUnit(darkRiders);
        army.AddUnit(darkRiders2);
        army.AddUnit(darkRiders3);
        army.AddUnit(coldOneKnights);

        return army;
    }

    public TowArmy GetSampleDarkElfArmy()
    {
        TowFaction faction = new DarkElvesTowFaction();

        TowArmy army = new(faction, 2000, "Dark Elves default");

        army.SetArmyComposition(new DarkElvesArmyComposition(army));

        //var supremeSorceress = new SupremeSorceressTowCharacter(army);
        //supremeSorceress.SetMount(new BlackDragonTowCharacterMount(supremeSorceress));
        //supremeSorceress.SetMagicItem(new LoreFamiliarTowArcaneItem(supremeSorceress));
        //supremeSorceress.SetMagicItem(new PendantOfKhaelethTowTalisman(supremeSorceress));
        //supremeSorceress.SetMagicLore(TowMagicLoreType.Daemonology);

        //var secondSupremeSorceress = new SupremeSorceressTowCharacter(army);
        //secondSupremeSorceress.SetMagicLevel(TowMagicLevelType.Level4);
        //secondSupremeSorceress.SetMount(new DarkPegasusTowCharacterMount(secondSupremeSorceress));
        //secondSupremeSorceress.SetMagicLore(TowMagicLoreType.Illusion);

        //secondSupremeSorceress.SetMagicItem(new TomeOfFurionTowArcaneItem(secondSupremeSorceress));
        //secondSupremeSorceress.SetMagicItem(new FocusFamiliarTowArcaneItem(secondSupremeSorceress, 7));

        var deathHag = new DeathHagTowCharacter(army);
        deathHag.SetMagicItem(new RuneOfKhaineRuneOfKhaine(deathHag));
        deathHag.SetMagicItem(new OgreBladeTowMagicWeapon(deathHag));


        //army.AddCharacter(supremeSorceress);
        //army.AddCharacter(secondSupremeSorceress);
        army.AddCharacter(deathHag);

        //var witchElves = new TowUnit(
        //    new WitchElfTowModel(army), 20, faction, true, true, true
        //    );
        //witchElves.SetMagicStandard(new BannerOfHarGanethTowMagicBanner(witchElves));

        //var darkRiders = new TowUnit(
        //    new DarkRiderTowModel(army), 6, faction, false, false, false
        //    );
        //darkRiders.SetWeapon(new RepeaterCrossbowTowWeapon(darkRiders));
        //darkRiders.SetArmor(new ShieldTowArmour(darkRiders));

        //var darkRiders2 = new TowUnit(
        //    new DarkRiderTowModel(army), 6, faction, false, true, false
        //    );
        //darkRiders2.SetWeapon(new RepeaterCrossbowTowWeapon(darkRiders2));
        //darkRiders2.SetArmor(new ShieldTowArmour(darkRiders2));

        //var coldOneKnights = new TowUnit(
        //    new ColdOneKnightTowModel(army), 7, faction, true, true, true
        //    );
        //coldOneKnights.SetArmor(new FullPlateArmourTowArmour(coldOneKnights));
        //coldOneKnights.SetMagicStandard(new WarBannerTowMagicBanner(coldOneKnights));

        //var harpies = new TowUnit(
        //    new HarpyTowModel(army), 6, faction, false, false, false
        //    );

        //var kharibdyss = new TowUnit(
        //    new KharibdyssTowModel(army), 1, faction, false, false, false
        //    );

        //army.AddUnit(witchElves);
        //army.AddUnit(darkRiders);
        //army.AddUnit(darkRiders2);
        //army.AddUnit(coldOneKnights);
        //army.AddUnit(harpies);
        //army.AddUnit(kharibdyss);

        return army;
    }
}
