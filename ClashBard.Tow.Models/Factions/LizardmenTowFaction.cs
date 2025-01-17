using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class LizardmenTowFaction : TowFaction
{
    public LizardmenTowFaction()
    {
        FactionType = TowFactionType.Lizardmen;
    }
}

public class LizardmenGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public LizardmenGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
