using ClashBard.Tow.Models;

namespace ClashBard.Tow.StaticData.Repositories.Interfaces;

public interface ITypeRepository<Entity, EntityTypeEnum>
{
    Entity GetByType(EntityTypeEnum type);
}