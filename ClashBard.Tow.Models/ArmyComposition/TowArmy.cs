using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.StaticData;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.ArmyComposition;
public class TowArmy : TowObject
{
    public TowFaction Faction { get; private set; }
    public string Name { get; private set; }
    public int ArmyPoints { get; private set; }

    public TowArmy(TowFaction faction, int points, string name)
    {
        ArmyPoints = points;
        Name = name;
        Faction = faction;
    }

    private TowArmyComposition ArmyComposition { get; set; }

    public void SetArmyComposition(TowArmyComposition armyComposition)
    {
        ArmyComposition = armyComposition;
    }

    //public ICollection<TowModel> Models { get; set; }

    protected List<TowCharacter> Characters { get; set; } = new List<TowCharacter>();

    public ICollection<TowCharacter> GetCharacters()
    {
        return Characters.ToList();
    }

    public TowArmy AddCharacter(TowCharacter character)
    {
        Characters.Add(character);

        return this;
    }

    protected List<TowUnit> Units { get; set; } = new List<TowUnit>();

    public ICollection<TowUnit> GetUnits()
    {
        return Units.ToList();
    }

    public TowArmy AddUnit(TowUnit unit)
    {
        Units.Add(unit);

        return this;
    }

    public TowCharacter General { get; set; }

    private TowCharacterBsb? _battleStandardBearer;
    public TowCharacterBsb? BattleStandardBearer
    {
        get => _battleStandardBearer; set
        {
            if (_battleStandardBearer != null)
            {
                _battleStandardBearer.SetAsArmyBattleStandardBearer(false);
            }

            value?.SetAsArmyBattleStandardBearer(true);
            _battleStandardBearer = value;
        }
    }

    public string FactionName => Faction.FactionType.ToNameString();

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

        if (Units.Where(p => p.Model.ModelTroopType == TowModelTroopType.WarMachine).Any())
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
        int totalMagicLevel = 0;
        StringBuilder magicLevelsStringBuilder = new();
        int numberOfMages = 0;

        foreach (var mage in Characters.OfType<IMagicUser>())
        {
            totalMagicLevel += mage.MagicLevel;
            magicLevelsStringBuilder.Append($"{mage.MagicLevel} + ");
            numberOfMages++;
        }

        if (numberOfMages == 0)
        {
            return "0";
        }
        else if (numberOfMages == 1)
        {
            return $"{totalMagicLevel}";
        }

        var allMagicLevels = magicLevelsStringBuilder.ToString().TrimEnd(" + ".ToCharArray());

        return $"{totalMagicLevel} ({allMagicLevels})";
    }

    public int GetTotalUnitStrength()
    {
        int totalUnitStrength = 0;
        foreach (var character in Characters)
        {
            totalUnitStrength += character.UnitStrength();
        }

        foreach (var unit in Units)
        {
            totalUnitStrength += unit.UnitStrength();
        }

        return totalUnitStrength;
    }

    public IEnumerable<ValidationError> Validate()
    {
        if(ArmyComposition == null)
        {
            yield return new ValidationError("Army composition not set", "Army");
        }
        else
        {
            foreach (var error in ArmyComposition.Validate())
            {
                yield return error;
            }
        }

        if(GetTotalPoints() > ArmyPoints)
        {
            yield return new ValidationError($"Army has exceeded the maximum points allowance of {ArmyPoints}", "Army");
        }

        foreach (var character in Characters)
        {
            foreach (var error in character.Validate())
            {
                yield return error;
            }
        }
        foreach (var unit in Units)
        {
            foreach (var error in unit.Model.Validate())
            {
                yield return error;
            }
        }
        

        // check if lances are only in cavalry units/properly mounted characters

        // check if army has general

        // check for army compoistion rules (grand army/arcane journal)
    }
}
