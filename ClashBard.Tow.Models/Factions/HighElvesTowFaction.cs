using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class HighElvesTowFaction : TowFaction
{
    public HighElvesTowFaction()
    {
        FactionType = TowFactionType.HighElves;
    }
}

public class HighElvesGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public HighElvesGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
