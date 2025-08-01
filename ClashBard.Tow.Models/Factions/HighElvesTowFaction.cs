using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.Factions.ArmyCompositions;
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
        var highElvesComposition = new HighElvesArmyComposition(_towArmy);
        highElvesComposition.Validate();

        // 0-1 unit of sea guard per 1000 pts may have Veteran special rule
        // 0-1 unit of spearmen/archers per 1000 pts may have Magic standard up to 50 pts
    }
}
