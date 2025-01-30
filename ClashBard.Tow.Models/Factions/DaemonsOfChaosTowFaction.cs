using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class DaemonsOfChaosTowFaction : TowFaction
{
    public DaemonsOfChaosTowFaction()
    {
        FactionType = TowFactionType.DaemonsOfChaos;
    }
}

public class DaemonsOfChaosGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public DaemonsOfChaosGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
