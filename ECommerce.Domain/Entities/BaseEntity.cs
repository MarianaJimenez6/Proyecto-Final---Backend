//ECommerce.Domain/Entities/BaseEntity.cs
namespace ECommerce.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();

    protected BaseEntity() { }

    protected BaseEntity(Guid id)
    {
        Id = id;
    }
}