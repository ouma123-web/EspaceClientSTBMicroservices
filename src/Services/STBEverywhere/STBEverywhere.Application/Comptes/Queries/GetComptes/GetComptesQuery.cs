using BuildingBlocks.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Comptes.Queries.GetComptes
{
    
    public record GetComptesQuery(PaginationRequest PaginationRequest)
    : IQuery<GetComptesResult>;

    public record GetComptesResult(PaginatedResult<CompteDto> Comptes);
}
