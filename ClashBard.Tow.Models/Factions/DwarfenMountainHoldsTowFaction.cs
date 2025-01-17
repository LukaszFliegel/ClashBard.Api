using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class DwarfenMountainHoldsTowFaction : TowFaction
{
    public DwarfenMountainHoldsTowFaction()
    {
        FactionType = TowFactionType.DwarfenMountainHolds;
    }
}

public class DwarfenMountainHoldsGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public DwarfenMountainHoldsGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
