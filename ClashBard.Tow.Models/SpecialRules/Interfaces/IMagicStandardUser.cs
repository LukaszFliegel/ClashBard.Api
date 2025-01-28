using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.SpecialRules.Interfaces;

public interface IMagicStandardUser
{
    TowMagicStandard? MagicStandard { get; }

    int MagicStandardUpToPoints { get; }

    //public void SetMagicStandard(TowMagicStandard magicStandard)
    //{
    //    if (magicStandard.Points > MagicStandardUpToPoints)
    //        throw new ArgumentException($"{magicStandard.MagicItemType} cost exceeds available {MagicStandardUpToPoints} for {GetType().Name}");

    //    MagicStandard = magicStandard;
    //}
}
