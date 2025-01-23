using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.Armors.Interfaces;

public interface IWardSaveImprover
{
    public int? MeleeWardSaveBaseline { get; }
    public int MeleeWardSaveImprovement { get; }

    public int? RangedWardSaveBaseline { get; }
    public int RangedWardSaveImprovement { get; }

    public bool AsteriskOnWardSave { get; }
}
