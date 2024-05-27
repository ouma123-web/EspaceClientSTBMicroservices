using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using STBEverywhere.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Cartes.Queries.GetCartes
{
    public class GetCartesHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCartesQuery, GetCartesResult>
    {

        public async Task<GetCartesResult> Handle(GetCartesQuery query, CancellationToken cancellationToken)
        {

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Cartes.LongCountAsync(cancellationToken);

            var cartes = await dbContext.Cartes
                .OrderBy(ca => ca.Id.Value)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new GetCartesResult(
                new PaginatedResult<CarteDto>(
                     pageIndex,
                     pageSize,
                     totalCount,
                     cartes.ToCarteDtoList())
                );

        }
    }

}
