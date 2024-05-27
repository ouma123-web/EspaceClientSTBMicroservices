using BuildingBlocks.Pagination;
using STBEverywhere.Application.CreditClients.Queries.GetClientCredit;
using STBEverywhere.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.CreditClients.Queries.GetClientCredits
{
    public class GetClientCreditsHandler(IApplicationDbContext dbContext)
        : IQueryHandler<GetClientCreditsQuery, GetClientCreditsResult>
    {
        public async Task<GetClientCreditsResult> Handle(GetClientCreditsQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.CreditClients.LongCountAsync(cancellationToken);

            var clientcredits = await dbContext.CreditClients
                
                .OrderBy(ccl => ccl.Id.Value)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new GetClientCreditsResult(
                new PaginatedResult<CreditClientDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    clientcredits.ToCreditClientDtoList()
                    ));

        }
    }
}
