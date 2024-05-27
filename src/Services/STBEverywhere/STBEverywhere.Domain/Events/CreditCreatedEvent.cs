

namespace STBEverywhere.Domain.Events
{
    



    public record CreditCreatedEvent(Credit credit) : IDomainEvent;
}
