using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using STBEverywhere.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Clients.Queries.GetClients
{
    public class GetClientsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetClientsQuery, GetClientsResult>
    {
        public async Task<GetClientsResult> Handle(GetClientsQuery query, CancellationToken cancellationToken)
        {

            // get orders with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Clients.LongCountAsync(cancellationToken);

            var clients = await dbContext.Clients
                                   .Include(c => c.Comptes)
                                   .Include(c => c.Cartes)
                                   .Include(c => c.CreditClients)
                                   .Skip(pageSize * pageIndex)
                                   .Take(pageSize)
                                   .ToListAsync(cancellationToken);

            return new GetClientsResult(
                new PaginatedResult<ClientDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    clients.ToClientDtoList()));
        }
    }
}
