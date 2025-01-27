using ClashBard.Tow.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models;
public class TowArmy: TowObject
{
    public string Name { get; set; }
    public int Points { get; set; }
    public TowFaction Faction { get; set; }
    //public ICollection<TowModel> Models { get; set; }

    public List<TowCharacter> Characters { get; set; } = new List<TowCharacter>();

    public List<TowUnit> Units { get; set; } = new List<TowUnit>();

    public TowCharacter General { get; set; }

    public void Validate()
    {
        // check if lances are only in cavalry units/properly mounted characters

        // check if army has general

        // check for army compoistion rules (grand army/arcane journal)
    }

    public string FactionName => Faction.FactionType.ToDescriptionString();

    public int GetTotalPoints()
    {
        int totalPoints = 0;
        foreach (var character in Characters)
        {
            totalPoints += character.CalculateTotalCost();
        }
        foreach (var unit in Units)
        {
            totalPoints += unit.CalculateTotalCost();
        }
        return totalPoints;
    }

    public string GetNumberOfDeploymentsString()
    {
        int deployments = 0;

        if (Characters.Any())
        {
            deployments++;
        }

        if(Units.Where(p => p.Model.ModelTroopType == TowModelTroopType.WarMachine).Any())
        {
            deployments++;
        }

        foreach (var unit in Units.Where(p => p.Model.ModelTroopType != TowModelTroopType.WarMachine && !p.Model.IsScout()))
        {
            deployments++;
        }

        var numberOfScouts = Units.Count(p => p.Model.IsScout());
        var scoutsString = numberOfScouts > 0 ? $" + {numberOfScouts} scouts" : string.Empty;

        return $"{deployments}{scoutsString}";
    }

    public int GetNumberOfVanguards()
    {
        return Units.Count(p => p.Model.IsVanguard());
    }

    public int GetNumberOfAmbushers()
    {
        return Units.Count(p => p.Model.IsAmbusher());
    }

    public string GetMagicLvlString()
    {
        return $"9 (4 + 3 + 2)";
    }

    public int GetTotalUnitStrength()
    {
        return 999;
    }
}
