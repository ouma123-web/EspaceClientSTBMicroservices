
namespace STBEverywhere.Domain.Events
{
    public record CarteUpdateEvent(Carte Carte) : IDomainEvent;
    
}
