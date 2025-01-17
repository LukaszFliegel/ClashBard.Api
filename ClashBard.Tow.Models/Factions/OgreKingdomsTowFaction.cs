using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class OgreKingdomsTowFaction : TowFaction
{
    public OgreKingdomsTowFaction()
    {
        FactionType = TowFactionType.OgreKingdoms;
    }
}

public class OgreKingdomsGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public OgreKingdomsGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
