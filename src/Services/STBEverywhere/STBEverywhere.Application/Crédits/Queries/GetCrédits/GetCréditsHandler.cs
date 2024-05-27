using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using STBEverywhere.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Crédits.Queries.GetCrédits
{
    public class GetCréditsHandler(IApplicationDbContext dbContext)
        : IQueryHandler<GetCréditsQuery, GetCreditResult>
    {

        public async Task<GetCreditResult> Handle(GetCréditsQuery query, CancellationToken cancellationToken)
        {

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Credits.LongCountAsync(cancellationToken);

            var credits = await dbContext.Credits
                       .Include(cr => cr.CreditClients)
                       .OrderBy(cr => cr.Id.Value)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

            return new GetCreditResult(
                new PaginatedResult<CreditDto>(
                pageIndex,
                pageSize,
                totalCount,
                credits.ToCreditDtoList()));      
                

        }

    }
}
