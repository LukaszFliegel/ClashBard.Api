using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;
using System.Collections.Immutable;
using System.Reflection;
using System.Text;

namespace ClashBard.Tow.Models;

public abstract class TowObjectWithSpecialRules: TowObjectWithOwner, ITowValidatable
{
    //private ICollection<TowSpecialRule> _specialRules = new HashSet<TowSpecialRule>();    

    protected ICollection<TowSpecialRule> SpecialRules { get; set; } = new HashSet<TowSpecialRule>();

    public ICollection<TowSpecialRule> GetSpecialRules()
    {
        return SpecialRules.ToList();
    }

    protected TowObjectWithSpecialRules(TowObject owner)
        : base(owner)
    {
        
    }

    public virtual Dictionary<string, string> GetSpecialRulesStrings(TowSpecialRuleType[]? excludeRules = null)
    {
        Dictionary<string, string> rules = new();

        if (excludeRules != null && excludeRules.Length > 0)
        {
            foreach (var rule in SpecialRules.Where(p => p.PrintInSummary && !excludeRules.Contains(p.RuleType)))
            {
                var ruleStrings = rule.GetRuleStrings();
                rules.Add(ruleStrings.Item1, ruleStrings.Item2);
            }
        }
        else
        {
            foreach (var rule in SpecialRules.Where(p => p.PrintInSummary))
            {
                var ruleStrings = rule.GetRuleStrings();
                rules.Add(ruleStrings.Item1, ruleStrings.Item2);
            }
        }

        return rules;
    }

    public virtual string GetSpecialRulesShortDescription(TowSpecialRuleType[]? excludeRules = null)
    {
        StringBuilder shortDescriptionSb = new();
        string separator = ClashBardStatic.Separator;

        if (excludeRules != null && excludeRules.Length > 0)
        {
            foreach (var rule in SpecialRules.Where(p => p.PrintInSummary && !excludeRules.Contains(p.RuleType)))
            {
                shortDescriptionSb.Append($"{rule.GetShortDescription()}{separator}");
            }
        }
        else
        {
            foreach (var rule in SpecialRules.Where(p => p.PrintInSummary))
            {
                shortDescriptionSb.Append($"{rule.GetShortDescription()}{separator}");
            }
        }

        return shortDescriptionSb.ToString().TrimEnd(separator.ToCharArray());
    }

    protected void AssignSpecialRule(TowSpecialRule towSpecialRule)
    {
        SpecialRules.Add(towSpecialRule);

        if (this is ISavesBearer savesBearer)
        {
            if (towSpecialRule is ISaveImprover saveImprover)
            {
                savesBearer.RegisterSaveImprover(saveImprover);
            }

            if (towSpecialRule is IWardSaveImprover wardSaveImprover)
            {
                savesBearer.RegisterWardSaveImprover(wardSaveImprover);
            }
        }

        if (Owner is ISavesBearer ownerSavesBearer)
        {
            if (towSpecialRule is ISaveImprover saveImprover)
            {
                ownerSavesBearer.RegisterSaveImprover(saveImprover);
            }

            if (towSpecialRule is IWardSaveImprover wardSaveImprover)
            {
                ownerSavesBearer.RegisterWardSaveImprover(wardSaveImprover);
            }
        }
    }

    public virtual IEnumerable<ValidationError> Validate()
    {
        foreach (var rule in SpecialRules.OfType<ITowValidatable>())
        {
            foreach (var error in rule.Validate())
            {
                yield return error;
            }
        }
    }
}
