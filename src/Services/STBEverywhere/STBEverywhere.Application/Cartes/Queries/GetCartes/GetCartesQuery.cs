using BuildingBlocks.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Cartes.Queries.GetCartes
{
    public record GetCartesQuery(PaginationRequest PaginationRequest)
     : IQuery<GetCartesResult>;


    public record GetCartesResult(PaginatedResult<CarteDto> cartes);
}
