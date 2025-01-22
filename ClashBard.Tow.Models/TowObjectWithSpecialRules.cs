using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;
using System.Reflection;
using System.Text;

namespace ClashBard.Tow.Models;

public abstract class TowObjectWithSpecialRules
{
    public virtual ICollection<TowSpecialRule> SpecialRules { get; set; } = new HashSet<TowSpecialRule>();

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
}
