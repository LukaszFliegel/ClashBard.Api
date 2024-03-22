using ClashBard.Tow.Models;

namespace ClashBard.Tow.StaticData.Repositories.Interfaces;

public interface IFactionRepository
{    
    TowModel GetModelByType(Enum modelType);

    TowCharacter GetCharacterByType(Enum characterType);
}