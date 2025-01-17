using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class WarHydraTowModel : TowModel
{
    private static int pointsCost = 200;
    private static TowModelMountType modelType = TowModelMountType.WarHydra;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.Behemoth;
    private const int baseSizeWidth = 60;
    private const int baseSizeLength = 100;
    private const int minUnitSize = 1;
    private const int maxUnitSize = 1;
    private const int armorValue = 5;

    public WarHydraTowModel() : this(m: 6, ws: 4, bs: 0, s: 5, t: 5, w: 5, i: 3, a: 2, ld: 6)
    {
        Crew.Add(new BeastmasterHandlersTowModelAdditional());
        Crew.Add(new BeastmasterHandlersTowModelAdditional());

        Weapons.Add(new WickedClawsTowWeapon());
        Weapons.Add(new SerratedMawsTowWeapon());
        Weapons.Add(new FieryBreathTowWeapon());

        SpecialRules.Add(new CloseOrder());
        SpecialRules.Add(new ExtraAttacksPlusRemainingWounds());
        SpecialRules.Add(new ImmuneToPsychology());
        SpecialRules.Add(new LargeTarget());
        SpecialRules.Add(new MonsterHandlers());
        SpecialRules.Add(new Regeneration5Plus());
        SpecialRules.Add(new StompAttacksD3());
        SpecialRules.Add(new Terror());
    }

    protected WarHydraTowModel(int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(modelType, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, minUnitSize, maxUnitSize, armorValue)
    {
    }
}
