using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class BeastmenBrayherdsTowFaction : TowFaction
{
    public BeastmenBrayherdsTowFaction()
    {
        FactionType = TowFactionType.BeastmenBrayherds;
    }
}

public class BeastmenBrayherdsGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public BeastmenBrayherdsGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
