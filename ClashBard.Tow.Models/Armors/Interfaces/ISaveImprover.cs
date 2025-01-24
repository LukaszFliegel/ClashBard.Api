using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.Armors.Interfaces;

public interface ISaveImprover
{
    public int? MeleeSaveBaseline { get; }
    public int MeleeSaveImprovement { get; }

    public int? RangedSaveBaseline { get; }
    public int RangedSaveImprovement { get; }

    public bool AsteriskOnSave { get; }
}
