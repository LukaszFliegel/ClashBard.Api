using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Models.Armors.Interfaces;

public interface ISavesBearer
{
    ICollection<ISaveImprover> SaveImprovers { get; set; }
    ICollection<IWardSaveImprover> WardSaveImprovers { get; set; }

    void RegisterSaveImprover(ISaveImprover saveImprover);
    void RegisterWardSaveImprover(IWardSaveImprover wardSaveImprover);

    public int? GetMeleeSave()
    {
        int? meleeSave = (SaveImprovers.Where(p => p.MeleeSaveBaseline.HasValue).OrderBy(p => p.MeleeSaveBaseline).FirstOrDefault())?.MeleeSaveBaseline;
        int meleeSaveImprovement = 0;
        foreach (var saveImprover in SaveImprovers)
        {
            meleeSaveImprovement += saveImprover.MeleeSaveImprovement;
        }

        if (meleeSaveImprovement > 0 && meleeSave == null)
            meleeSaveImprovement = 7;

        meleeSave -= meleeSaveImprovement;

        return meleeSave;
    }

    public int? GetRangedSave()
    {
        int? rangedSave = (SaveImprovers.Where(p => p.RangedSaveBaseline.HasValue).OrderBy(p => p.RangedSaveBaseline).FirstOrDefault())?.RangedSaveBaseline;
        int rangedSaveImprovement = 0;
        foreach (var saveImprover in SaveImprovers)
        {
            rangedSaveImprovement += saveImprover.RangedSaveImprovement;
        }

        if (rangedSaveImprovement > 0 && rangedSave == null)
            rangedSaveImprovement = 7;

        rangedSave -= rangedSaveImprovement;

        return rangedSave;
    }


    public int? GetMeleeWardSave()
    {
        int? meleeWardSave = (WardSaveImprovers.Where(p => p.MeleeWardSaveBaseline.HasValue).OrderBy(p => p.MeleeWardSaveBaseline).FirstOrDefault())?.MeleeWardSaveBaseline;
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

    public int? GetRangedWardSave()
    {
        int? rangedWardSave = (WardSaveImprovers.Where(p => p.RangedWardSaveBaseline.HasValue).OrderBy(p => p.RangedWardSaveBaseline).FirstOrDefault())?.RangedWardSaveBaseline;
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