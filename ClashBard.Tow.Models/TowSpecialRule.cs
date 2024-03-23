using ClashBard.Tow.Models.TowTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models;

public class TowSpecialRule
{
    public TowSpecialRule(TowSpecialRuleType ruleType, string shortDescription, string longDescription)
    {
        RuleType = ruleType;
        ShortDescription = shortDescription;
        LongDescription = longDescription;
    }

    //[Key]
    //public int Id { get; set; }
    //public string Name { get; set; }

    public TowSpecialRuleType RuleType { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }

    //public ICollection<TowModel> TowModel { get; set; }
}
