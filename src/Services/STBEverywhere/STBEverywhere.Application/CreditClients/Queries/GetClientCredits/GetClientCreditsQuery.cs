using BuildingBlocks.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.CreditClients.Queries.GetClientCredit
{
    public record GetClientCreditsQuery(PaginationRequest PaginationRequest)
        :IQuery<GetClientCreditsResult>;
    
    public record GetClientCreditsResult(PaginatedResult<CreditClientDto> ClientCredits);
}
