
namespace STBEverywhere.Application.Clients.Queries.GetClientsById
{
    public record GetClientsByIdQuery(int Id) 
        : IQuery<GetClientsByIdResult>;
    
    public record GetClientsByIdResult(IEnumerable<ClientDto> Clients);
}
