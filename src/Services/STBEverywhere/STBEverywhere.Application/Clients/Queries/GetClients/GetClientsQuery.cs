using BuildingBlocks.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Clients.Queries.GetClients
{
    public record GetClientsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetClientsResult>;

    public record GetClientsResult(PaginatedResult<ClientDto> Cliens);
}
