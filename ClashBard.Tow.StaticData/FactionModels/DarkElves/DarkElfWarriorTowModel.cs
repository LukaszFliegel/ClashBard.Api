using ClashBard.Tow.Models;
using ClashBard.Tow.Models.TowTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.StaticData.FactionModels.DarkElves;

public class DarkElfWarriorTowModel : TowModel
{
    public DarkElfWarriorTowModel(): base(TowDarkElfModelType.DarkElfWarriors, m: 5, ws: 4, bs: 4, s: 3, t: 3, w: 1, i: 4, a: 1, ld: 8)
    {
        ModelType = TowDarkElfModelType.DarkElfWarriors;

        //AvailableWeapons.Add();
    }
}
