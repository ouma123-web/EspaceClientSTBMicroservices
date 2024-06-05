using Microsoft.EntityFrameworkCore;
using STBEverywhere.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Comptes.Queries.GetComptesByOpération
{
    public class GetComptesByOpérationHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetComptesByOpérationQuery, GetComptesByOpérationResult>
    {

        public async Task<GetComptesByOpérationResult> Handle(GetComptesByOpérationQuery query, CancellationToken cancellationToken)
        {
            // get comptes by opération using dbContext
            // return result

            var comptes = await dbContext.Comptes
                            .AsNoTracking()
                            .Where(co => co.OpérationId == OpérationId.Of(query.OpérationId))
                            .OrderBy(co => co.Id.Value)
                            .ToListAsync(cancellationToken);

            return new GetComptesByOpérationResult(comptes.ToCompteDtoList());
        }

    }
}
