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
            new TowFaction { FactionType = TowFactionType.EmpireOfMan },
            new TowFaction { FactionType = TowFactionType.OrcAndGoblinTribes},
            new TowFaction { FactionType = TowFactionType.DwarfenMountainHolds},
            new TowFaction { FactionType = TowFactionType.WarriorsOfChaos},
            new TowFaction { FactionType = TowFactionType.KingdomOfBretonnia},
            new TowFaction { FactionType = TowFactionType.BeastmenBrayherds},
            new TowFaction { FactionType = TowFactionType.WoodElves},
            new TowFaction { FactionType = TowFactionType.TombKingsOfKhemri},
            new TowFaction { FactionType = TowFactionType.HighElves},
            new TowFaction { FactionType = TowFactionType.DarkElves},
            new TowFaction { FactionType = TowFactionType.Skaven},
            new TowFaction { FactionType = TowFactionType.VampireCounts},
            new TowFaction { FactionType = TowFactionType.DaemonsOfChaos},
            new TowFaction { FactionType = TowFactionType.OgreKingdoms},
            new TowFaction { FactionType = TowFactionType.Lizardmen},
            new TowFaction { FactionType = TowFactionType.ChaosDwarfs }
        };

        Factions.AddRange(factionsTemp);
    }
}
