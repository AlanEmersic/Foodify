namespace Foodify.Domain.Common;

public abstract class AggregateRoot : Entity
{
    protected readonly List<IDomainEvent> domainEvents = new();

    public List<IDomainEvent> PopDomainEvents()
    {
        List<IDomainEvent> copy = domainEvents.ToList();
        domainEvents.Clear();

        return copy;
    }
}