using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.ArmyComposition;

public abstract class TowArmyComposition : ITowValidatable
{
    protected ICollection<TowCharacter> AvailableCharacters { get; private set; } = new HashSet<TowCharacter>();

    protected ICollection<TowUnit> AvailableCoreUnits { get; private set; } = new HashSet<TowUnit>();

    protected ICollection<TowUnit> AvailableSpecialUnits { get; private set; } = new HashSet<TowUnit>();

    protected ICollection<TowUnit> AvailableRareUnits { get; private set; } = new HashSet<TowUnit>();

    protected ICollection<ArmyCompositionRule> armyCompositionRules { get; private set; } = new HashSet<ArmyCompositionRule>();

    public IEnumerable<ValidationError> Validate()
    {
        foreach (var rule in armyCompositionRules)
        {
            foreach (var error in rule.Validate())
            {
                yield return error;
            }
        }
    }
}

public abstract class ArmyCompositionRule : ITowValidatable
{
    public abstract IEnumerable<ValidationError> Validate();
}

public class TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints<FactionModelEnumType> : ArmyCompositionRule where FactionModelEnumType : Enum
{
    private readonly TowArmy army;
    private readonly FactionModelEnumType modelType;
    private readonly int upToHowManuUnits;
    private readonly int perHowManyPoints;

    public TowArmyCompositionRuleZeroToXNumberOfUnitsPerXPoints(TowArmy army, FactionModelEnumType modelType, int upToHowManuUnits, int perHowManyPoints = 1000)
    {
        this.army = army;
        this.modelType = modelType;
        this.upToHowManuUnits = upToHowManuUnits;
        this.perHowManyPoints = perHowManyPoints;
    }

    public override IEnumerable<ValidationError> Validate()
    {
        // check if in army units there is 0-upToHowManuUnits of modelType for each perHowManyPoints
        var units = army.GetUnits().Where(u => EqualityComparer<FactionModelEnumType>.Default.Equals((FactionModelEnumType)u.Model.ModelType, modelType));
        var points = army.ArmyPoints;
        
        if(units.Count() > upToHowManuUnits * points/1000)
        {
            yield return new ValidationError($"Too many units of type {modelType.ToNameString()} in army. Up to {upToHowManuUnits} allowed per 1000 points.", modelType.ToNameString());
        }
    }
}

public class TowArmyCompositionRuleZeroToXNumberOfUnitMountsPerXPoints<FactionModelMountEnumType> : ArmyCompositionRule where FactionModelMountEnumType : Enum
{
    private readonly TowArmy army;
    private readonly FactionModelMountEnumType modelType;
    private readonly int upToHowManuUnits;
    private readonly int perHowManyPoints;

    public TowArmyCompositionRuleZeroToXNumberOfUnitMountsPerXPoints(TowArmy army, FactionModelMountEnumType modelType, int upToHowManuUnits, int perHowManyPoints = 1000)
    {
        this.army = army;
        this.modelType = modelType;
        this.upToHowManuUnits = upToHowManuUnits;
        this.perHowManyPoints = perHowManyPoints;
    }

    public override IEnumerable<ValidationError> Validate()
    {
        // check if in army units there is 0-upToHowManuUnits of modelType mounts for each perHowManyPoints
        var mounts = army.GetCharacters().Where(u => u.Mount != null && EqualityComparer<FactionModelMountEnumType>.Default.Equals((FactionModelMountEnumType)u.Mount.ModelMountType, modelType));
        var points = army.ArmyPoints;

        if (mounts.Count() > upToHowManuUnits * points / 1000)
        {
            yield return new ValidationError($"Too many mounts of type {modelType.ToNameString()} in army. Up to {upToHowManuUnits} allowed per 1000 points.", modelType.ToNameString());
        }
    }
}