using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves;

public class KharibdyssTowModel : TowModel
{
    private static int pointsCost = 195;
    private static DarkElfTowModelType modelType = DarkElfTowModelType.Kharibdyss;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.Behemoth;
    private const int baseSizeWidth = 60;
    private const int baseSizeLength = 100;
    private const int minUnitSize = 1;
    private const int maxUnitSize = 1;
    private const int armourValue = 5;

    public KharibdyssTowModel(TowObject owner) : this(owner, m: 6, ws: 5, bs: 0, s: 7, t: 5, w: 5, i: 3, a: 5, ld: 6)
    {
    }

    protected KharibdyssTowModel(TowObject owner, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld) 
        : base(owner, modelType, m, ws, bs, s, t, w, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, minUnitSize, maxUnitSize, armourValue)
    {
        // special rules
        AssignSpecialRule(new AbyssalHowl());
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new ImmuneToPsychology());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new MonsterHandlers());
        AssignSpecialRule(new StompAttacksD3Plus1());
        AssignSpecialRule(new Terror());

        // weapons
        AssignDefault(new CavernousMawTowWeapon(this));
        AssignDefault(new WrithingTentaclesTowWeapon(this));

        // crew
        Crew.Add(new BeastmasterHandlersTowModelAdditional(this));
        Crew.Add(new BeastmasterHandlersTowModelAdditional(this));
    }
}
