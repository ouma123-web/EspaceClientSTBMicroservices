using BuildingBlocks.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Opérations.Queries.GetOpérations
{
    public record GetOpérationsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetOpérationsResult>;

    public record GetOpérationsResult(PaginatedResult<OpérationDto> Opérations);
}
