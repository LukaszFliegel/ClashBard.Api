using ClashBard.Tow.Models.Factions;
using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.Deprecated.Repositories;

public class FactionsListRepository : IFactionsListRepository
{
    private List<TowFaction> Factions = new List<TowFaction>();

    public FactionsListRepository()
    {
        SeedData();
    }

    public TowFaction GetByType(TowFactionType type)
    {
        var faction = Factions.Single(f => f.FactionType == type);
        return faction;
    }

    private void SeedData()
    {
        var factionsTemp = new List<TowFaction>
        {
            new EmpireOfManTowFaction(),
            new OrcAndGoblinTribesTowFaction(),
            new DwarfenMountainHoldsTowFaction(),
            new WarriorsOfChaosTowFaction(),
            new KingdomOfBretonniaTowFaction(),
            new BeastmenBrayherdsTowFaction(),
            new WoodElvesTowFaction(),
            new TombKingsOfKhemriTowFaction(),
            new HighElvesTowFaction(),
            new DarkElvesTowFaction(),
            new SkavenTowFaction(),
            new VampireCountsTowFaction(),
            new DaemonsOfChaosTowFaction(),
            new OgreKingdomsTowFaction(),
            new LizardmenTowFaction(),
            new ChaosDwarfsTowFaction()
        };

        Factions.AddRange(factionsTemp);
    }
}
