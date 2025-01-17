using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class WoodElvesTowFaction : TowFaction
{
    public WoodElvesTowFaction()
    {
        FactionType = TowFactionType.WoodElves;
    }
}

public class WoodElvesGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public WoodElvesGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
