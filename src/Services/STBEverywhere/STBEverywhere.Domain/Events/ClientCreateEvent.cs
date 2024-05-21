

namespace STBEverywhere.Domain.Events
{
    public record ClientCreateEvent(Client client) : IDomainEvent;
    
}
