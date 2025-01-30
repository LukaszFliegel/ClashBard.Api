using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class OrcAndGoblinTribesTowFaction : TowFaction
{
    public OrcAndGoblinTribesTowFaction()
    {
        FactionType = TowFactionType.OrcAndGoblinTribes;
    }
}

public class OrcAndGoblinTribesGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public OrcAndGoblinTribesGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
