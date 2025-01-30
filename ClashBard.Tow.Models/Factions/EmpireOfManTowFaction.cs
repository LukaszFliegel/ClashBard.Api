using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class EmpireOfManTowFaction : TowFaction
{
    public EmpireOfManTowFaction()
    {
        FactionType = TowFactionType.EmpireOfMan;
    }
}

public class EmpireOfManGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public EmpireOfManGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
