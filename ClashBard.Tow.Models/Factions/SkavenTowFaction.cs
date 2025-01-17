using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class SkavenTowFaction : TowFaction
{
    public SkavenTowFaction()
    {
        FactionType = TowFactionType.Skaven;
    }
}

public class SkavenGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public SkavenGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
