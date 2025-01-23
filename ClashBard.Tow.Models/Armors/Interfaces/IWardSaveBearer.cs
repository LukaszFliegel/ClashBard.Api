using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.Armors.Interfaces;

public interface IWardSaveBearer
{
    ICollection<IWardSaveImprover> WardSaveImprovers { get; set; }

    void RegisterWardSaveImprover(IWardSaveImprover wardSaveImprover);

    virtual int? GetMeleeWardSave()
    {
        int? meleeWardSave = (WardSaveImprovers.Where(p => p.MeleeWardSaveBaseline.HasValue).OrderBy(p => p.MeleeWardSaveBaseline).FirstOrDefault())?.MeleeWardSaveImprovement;
        int meleeWardSaveImprovement = 0;
        foreach (var wardSaveImprover in WardSaveImprovers)
        {
            meleeWardSaveImprovement += wardSaveImprover.MeleeWardSaveImprovement;
        }

        if (meleeWardSaveImprovement > 0 && meleeWardSave == null)
            meleeWardSaveImprovement = 7;

        meleeWardSave -= meleeWardSaveImprovement;

        return meleeWardSave;
    }

    virtual int? GetRangedWardSave()
    {
        int? rangedWardSave = (WardSaveImprovers.Where(p => p.RangedWardSaveBaseline.HasValue).OrderBy(p => p.RangedWardSaveBaseline).FirstOrDefault())?.RangedWardSaveImprovement;
        int rangedWardSaveImprovement = 0;
        foreach (var wardSaveImprover in WardSaveImprovers)
        {
            rangedWardSaveImprovement += wardSaveImprover.RangedWardSaveImprovement;
        }
        if (rangedWardSaveImprovement > 0 && rangedWardSave == null)
            rangedWardSaveImprovement = 7;

        rangedWardSave -= rangedWardSaveImprovement;

        return rangedWardSave;
    }
}