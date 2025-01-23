using ClashBard.Tow.Models.Armors.Interfaces;
using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;
using System.Reflection;
using System.Text;

namespace ClashBard.Tow.Models;

public abstract class TowObjectWithSpecialRules: TowObject
{
    //private ICollection<TowSpecialRule> _specialRules = new HashSet<TowSpecialRule>();    

    public ICollection<TowSpecialRule> SpecialRules { get; set; } = new HashSet<TowSpecialRule>();


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

    //protected void AssignSpecialRule(TowSpecialRule towSpecialRule)
    //{
    //    SpecialRules.Add(towSpecialRule);

    //    if(this is IWardSaveBearer && towSpecialRule is IWardSaveImprover)
    //    {
    //        (this as IWardSaveBearer).RegisterWardSaveImprover(towSpecialRule as IWardSaveImprover);
    //    }
    //}

    //protected ICollection<TowSpecialRule> GetSpecialRules()
    //{
    //    return SpecialRules.ToList();
    //}
}
