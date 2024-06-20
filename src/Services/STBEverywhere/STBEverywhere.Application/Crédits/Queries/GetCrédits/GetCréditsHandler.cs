using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using STBEverywhere.Application.Extensions;


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

            if (totalCount == 0)
            {
              var  credit = new List<Credit>();

                return new GetCreditResult(
              new PaginatedResult<CreditDto>(
              pageIndex,
              pageSize,
              totalCount,
              credit.ToCreditDtoList()));
            }

            var credits = await dbContext.Credits
                       .Include(cr => cr.CreditClients)
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
