using System.ComponentModel.DataAnnotations;

namespace ClashBard.Tow.Models;

public class TowCharacter : TowModel
{
    public TowCharacter()
    {
        ModelSlotType = TowModelSlotType.Character;
    }
}
