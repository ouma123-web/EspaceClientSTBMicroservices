using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using STBEverywhere.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace STBEverywhere.Application.Comptes.Queries.GetComptes
{
    public class GetComptesHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetComptesQuery, GetComptesResult>
    {
        public async Task<GetComptesResult> Handle(GetComptesQuery query, CancellationToken cancellationToken)
        {
            // get comptes with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Comptes.LongCountAsync(cancellationToken);

            var comptes = await dbContext.Comptes
                      .OrderBy(co => co.Id.Value)
                      .Skip(pageSize * pageIndex)
                      .Take(pageSize)
                      .ToListAsync(cancellationToken);

            return new GetComptesResult(
           new PaginatedResult<CompteDto>(
               pageIndex,
               pageSize,
               totalCount,
               comptes.ToCompteDtoList()));

        }
    }
}
