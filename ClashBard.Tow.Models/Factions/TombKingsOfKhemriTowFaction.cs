using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class TombKingsOfKhemriTowFaction : TowFaction
{
    public TombKingsOfKhemriTowFaction()
    {
        FactionType = TowFactionType.TombKingsOfKhemri;
    }
}

public class TombKingsOfKhemriGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public TombKingsOfKhemriGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
