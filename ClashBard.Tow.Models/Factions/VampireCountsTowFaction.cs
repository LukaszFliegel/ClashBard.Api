using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class VampireCountsTowFaction : TowFaction
{
    public VampireCountsTowFaction()
    {
        FactionType = TowFactionType.VampireCounts;
    }
}

public class VampireCountsGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public VampireCountsGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
