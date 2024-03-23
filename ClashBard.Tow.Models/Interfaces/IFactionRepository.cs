using ClashBard.Tow.Models;

namespace ClashBard.Tow.Models.Interfaces;

public interface IFactionRepository
{
    TowModel GetModelByType(Enum modelType);

    TowCharacter GetCharacterByType(Enum characterType);
}