using ClashBard.Tow.Models;

namespace ClashBard.Tow.Models.Interfaces;

public interface ITypeRepository<Entity, EntityTypeEnum>
{
    Entity GetByType(EntityTypeEnum type);
}