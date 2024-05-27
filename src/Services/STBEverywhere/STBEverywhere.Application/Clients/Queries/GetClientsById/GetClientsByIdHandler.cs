

using Microsoft.EntityFrameworkCore;
using STBEverywhere.Application.Extensions;

namespace STBEverywhere.Application.Clients.Queries.GetClientsById
{
    public class GetClientsByIdHandler(IApplicationDbContext dbContext)
        : IQueryHandler<GetClientsByIdQuery, GetClientsByIdResult>
    {
        public async Task<GetClientsByIdResult> Handle(GetClientsByIdQuery query, CancellationToken cancellationToken)
        {
            var clients = await dbContext.Clients
                .Include(c => c.Cartes)
                .Include(c => c.Comptes)
                .Include(c => c.CreditClients)
                .AsNoTracking()
                //.Where(c => c.ClientId.Value.Contains(query.Id))
                .OrderBy(c => c.Id.Value)
                .ToListAsync(cancellationToken);


            return new GetClientsByIdResult(clients.ToClientDtoList());
        }

    }
   
}
