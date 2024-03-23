using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowCharacter : TowModel
{
    public TowCharacter(Enum modelType, int? m, int ws, int bs, int s, int t, int w, int i, int a, int ld, int pointCost, TowModelTroopType modelTroopType/*, TowModelSlotType modelSlotType*/, TowFaction faction,
        int baseSizeWidth, int baseSizeLength,
        int minUnitSize = 1, int? maxUnitSize = null)
        :base(modelType, m, ws, bs, s, t, w, i, a, ld, pointCost, modelTroopType/*, modelSlotType*/, faction, baseSizeWidth, baseSizeLength, minUnitSize, maxUnitSize)
    {
        //ModelSlotType = TowModelSlotType.Character;
    }
}
