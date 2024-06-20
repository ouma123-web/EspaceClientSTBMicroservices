using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using STBEverywhere.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Opérations.Queries.GetOpérations
{
    public class GetOpérationsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOpérationsQuery, GetOpérationsResult>
    {
        public async Task<GetOpérationsResult> Handle(GetOpérationsQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Opérations.LongCountAsync(cancellationToken);

            var opérations = await dbContext.Opérations
                      .Include(o => o.Comptes)
                      .Skip(pageSize * pageIndex)
                      .Take(pageSize)
                      .ToListAsync(cancellationToken);


            return new GetOpérationsResult(
            new PaginatedResult<OpérationDto>(
                pageIndex,
                pageSize,
                totalCount,
                opérations.ToOpérationDtoList()));


        }

    }
}
