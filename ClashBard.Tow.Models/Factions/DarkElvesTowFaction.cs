using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class DarkElvesTowFaction : TowFaction
{
    public DarkElvesTowFaction()
    {
        FactionType = TowFactionType.DarkElves;
    }
}

public class DarkElvesGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public DarkElvesGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {
        //if(_towArmy.Models.Any(p => p.GetType().Equals(typeof(DarkElfWarriorTowModel))))
        //{

        //}

        // 0-1 unit of warriors/crossbowmens per 1000 pts may have Veteran special rule

        // 0-1 unit of warriors/crossbowmens per 1000 pts may have Magic standard to up to 50 pts
    }
}