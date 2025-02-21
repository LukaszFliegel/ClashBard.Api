using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class WarHydraTowModel : TowModel
{
    private static int pointsCost = 200;
    private static DarkElvesTowModelType modelType = DarkElvesTowModelType.WarHydra;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.Behemoth;
    private const int baseSizeWidth = 60;
    private const int baseSizeLength = 100;
    private const int minUnitSize = 1;
    private const int maxUnitSize = 1;
    private const int armourValue = 5;

    public WarHydraTowModel(TowObject owner) : this(owner, m: 6, ws: 4, bs: 0, s: 5, t: 5, w: 5, i: 3, a: 2, ld: 6)
    {
        
    }

    protected WarHydraTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, minUnitSize, maxUnitSize, armourValue)
    {
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ExtraAttacksPlusRemainingWounds());
        AssignSpecialRule(new ImmuneToPsychology());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new MonsterHandlers());
        AssignSpecialRule(new Regeneration5Plus());
        AssignSpecialRule(new StompAttacksD3());
        AssignSpecialRule(new Terror());

        // weapons
        AssignDefault(new WickedClawsTowWeapon(this));
        AssignDefault(new SerratedMawsTowWeapon(this));
        AssignDefault(new FieryBreathTowWeapon(this));

        // crew
        Crew.Add(new BeastmasterHandlersTowModelAdditional(this));
        Crew.Add(new BeastmasterHandlersTowModelAdditional(this));
    }
}
