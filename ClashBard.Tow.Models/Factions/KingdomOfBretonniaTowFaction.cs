using ClashBard.Tow.Models.TowTypes;

namespace ClashBard.Tow.Models.Factions;

public class KingdomOfBretonniaTowFaction : TowFaction
{
    public KingdomOfBretonniaTowFaction()
    {
        FactionType = TowFactionType.KingdomOfBretonnia;
    }
}

public class KingdomOfBretonniaGrandArmyComposition
{
    private readonly TowArmy _towArmy;

    public KingdomOfBretonniaGrandArmyComposition(TowArmy towArmy)
    {
        _towArmy = towArmy;
    }

    public void Validate()
    {

    }
}
