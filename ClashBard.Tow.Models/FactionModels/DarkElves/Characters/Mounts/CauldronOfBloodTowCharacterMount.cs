using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.MagicItems.DarkElves;
using ClashBard.Tow.Models.SpecialRules;
using ClashBard.Tow.Models.SpecialRules.DarkElvesSpecialRules;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.Models.Weapons;

namespace ClashBard.Tow.Models.FactionModels.DarkElves.Characters.Mounts;

public class CauldronOfBloodTowCharacterMount : TowModelCharacterMount
{
    private static int pointsCost = 150;
    private static DarkElvesTowModelMountType modelType = DarkElvesTowModelMountType.CauldronOfBlood;

    private static TowFaction faction = new DarkElvesTowFaction();

    private static TowModelTroopType troopType = TowModelTroopType.HeavyChariot;
    private const int baseSizeWidth = 60;
    private const int baseSizeLength = 100;
    private static int? armourValue = 4;

    public CauldronOfBloodTowCharacterMount(TowObject owner) : this(owner, m: 2, ws: null, bs: null, s: 5, t: 5, toughnessAdded: null, w: 5, woundsAdded: null, i: null, a: null, ld: null)
    {
        // special rules
        AssignSpecialRule(new CloseOrder());
        AssignSpecialRule(new DraggedAlong());
        AssignSpecialRule(new ElvenReflexes());
        AssignSpecialRule(new Frenzy());
        AssignSpecialRule(new HatredHighElves());
        AssignSpecialRule(new ImpactHitsD6Plus1());
        AssignSpecialRule(new LargeTarget());
        AssignSpecialRule(new MagicResistance1());
        AssignSpecialRule(new Murderous());
        AssignSpecialRule(new PoisonedAttacks());
        AssignSpecialRule(new Terror());
        AssignSpecialRule(new BlessingsOfKhaine());

        // crew
        Crew.Add(new WitchElfCrewTowModelAdditional(this));
        Crew.Add(new WitchElfCrewTowModelAdditional(this));

        // magic items
        MagicItems.Add(new FuryOfKhaineBlessingOfKhaine(this));
        MagicItems.Add(new StrengthOfKhaineBlessingOfKhaine(this));
        MagicItems.Add(new BloodshieldOfKhaineBlessingOfKhaine(this));
    }

    protected CauldronOfBloodTowCharacterMount(TowObject owner, int? m, int? ws, int? bs, int s, int? t, int? toughnessAdded, int? w, int? woundsAdded, int? i, int? a, int? ld)
        : base(owner, modelType, m, ws, bs, s, t, toughnessAdded, w, woundsAdded, i, a, ld, pointCost: pointsCost, troopType, faction, baseSizeWidth, baseSizeLength, armourValue)
    {
    }
}

public abstract class DarkElvesBlessingOfKhaine : TowMagicItem
{
    public DarkElvesBlessingOfKhaine(TowObject owner, TowDarkElvesMagicItemType type, int points) : base(owner, type, points, TowMagicItemCategory.FactionSpecificPrintAsWeapon)
    {
    }
}

public class FuryOfKhaineBlessingOfKhaine : DarkElvesBlessingOfKhaine
{
    public FuryOfKhaineBlessingOfKhaine(TowObject owner) : base(owner, TowDarkElvesMagicItemType.FuryOfKhaine, 0)
    {
        AssignSpecialRule(new FuryOfKhaine());
    }
}

public class StrengthOfKhaineBlessingOfKhaine : DarkElvesBlessingOfKhaine
{
    public StrengthOfKhaineBlessingOfKhaine(TowObject owner) : base(owner, TowDarkElvesMagicItemType.StrengthOfKhaine, 0)
    {
        AssignSpecialRule(new StrengthOfKhaine());
    }
}

public class BloodshieldOfKhaineBlessingOfKhaine : DarkElvesBlessingOfKhaine
{
    public BloodshieldOfKhaineBlessingOfKhaine(TowObject owner) : base(owner, TowDarkElvesMagicItemType.BloodshieldOfKhaine, 0)
    {
        AssignSpecialRule(new BloodshieldOfKhaine());
    }
}