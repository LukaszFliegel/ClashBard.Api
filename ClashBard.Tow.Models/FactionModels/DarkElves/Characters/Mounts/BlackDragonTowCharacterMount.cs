using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters.Mounts;

public class BlackDragonTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 280;
    private static DarkElfTowModelMountType modelType = DarkElfTowModelMountType.BlackDragon;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.Behemoth;
    private const int baseSizeWidth = 60;
    private const int baseSizeLength = 100;
    private static int? armourValue = 4;

    public BlackDragonTowCharacterMount(TowObject owner) : this(owner, m: 6, ws: 6, bs: null, s: 7, t: null, toughnessAdded: 3, w: null, woundsAdded: 6, i: 4, a: 6, ld: null)
    {
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new Fly10());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new StompAttacksD6());
        AssignSpecialRule(new Swiftstride());
        AssignSpecialRule(new Terror());

        // wespons
        AssignDefault(new WickedClawsTowWeapon(this));
        AssignDefault(new SerratedMawTowWeapon(this));
        AssignDefault(new NoxiousBreathTowWeapon(this));
    }

    protected BlackDragonTowCharacterMount(TowObject owner, int? m, int ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int i, int a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
    }
}
