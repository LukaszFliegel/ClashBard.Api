using ClashBard.Tow.Models.TowTypes;
using ClashBard.Tow.StaticData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models;

public class TowSpecialRule: TowObject
{
    

    public TowSpecialRule(TowSpecialRuleType ruleType, string shortDescription, string longDescription, 
        bool printInSummary = true,
        bool printName = true,
        bool printShortDescription = true)
    {
        RuleType = ruleType;
        this.shortDescription = shortDescription;
        LongDescription = longDescription;
        PrintInSummary = printInSummary;
        this.printName = printName;
        this.printShortDescription = printShortDescription;
    }

    //[Key]
    //public int Id { get; set; }
    //public string Name { get; set; }

    public TowSpecialRuleType RuleType { get; private set; }
    
    private string LongDescription { get; set; }

    public bool PrintInSummary { get; private set; }

    private string shortDescription;
    private readonly bool printName;
    private readonly bool printShortDescription;

    public string GetShortDescription()
    {
        StringBuilder shortDescriptionSb = new();
        string separator = ClashBardStatic.Separator;

        if (printName)
            shortDescriptionSb.Append($"{RuleType.ToDescriptionString()}");

        if (printName && printShortDescription)
            shortDescriptionSb.Append(": ");

        if (printShortDescription)
            shortDescriptionSb.Append($"{shortDescription.Trim()}");

        shortDescriptionSb.Append(separator);

        return shortDescriptionSb.ToString().TrimEnd(separator.ToCharArray());
    }
}
