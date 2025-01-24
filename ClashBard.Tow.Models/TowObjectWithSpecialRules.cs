using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;
using System.Reflection;
using System.Text;

namespace ClashBard.Tow.Models;

public abstract class TowObjectWithSpecialRules: TowObjectWithOwner
{
    //private ICollection<TowSpecialRule> _specialRules = new HashSet<TowSpecialRule>();    

    public ICollection<TowSpecialRule> SpecialRules { get; set; } = new HashSet<TowSpecialRule>();

    protected TowObjectWithSpecialRules(TowObject owner)
        : base(owner)
    {
        
    }

    public string GetSpecialRulesShortDescription()
    {
        StringBuilder shortDescriptionSb = new();
        string separator = ClashBardStatic.Separator;

        foreach (var rule in SpecialRules.Where(p => p.PrintInSummary))
        {
            shortDescriptionSb.Append($"{rule.GetShortDescription()}{separator}");
        }

        return shortDescriptionSb.ToString().TrimEnd(separator.ToCharArray());
    }

    protected void AssignSpecialRule(TowSpecialRule towSpecialRule)
    {
        SpecialRules.Add(towSpecialRule);

        if (Owner is ISavesBearer && towSpecialRule is IWardSaveImprover)
        {
            (Owner as ISavesBearer).RegisterWardSaveImprover(towSpecialRule as IWardSaveImprover);
        }

        if (Owner is ISavesBearer && towSpecialRule is ISaveImprover)
        {
            (Owner as ISavesBearer).RegisterSaveImprover(towSpecialRule as ISaveImprover);
        }
    }

    protected ICollection<TowSpecialRule> GetSpecialRules()
    {
        return SpecialRules.ToList();
    }
}
