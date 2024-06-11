using BuildingBlocks.Pagination;
using STBEverywhere.Application.Comptes.Queries.GetComptes;

namespace STBEverywhere.API.Endpoints
{

    public  record GetComptesResponse(PaginatedResult<CompteDto> Comptes);
    public class GetComptes : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/comptes", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetComptesQuery(request));

                //var response = result.Adapt<GetComptesResponse>();

                return Results.Ok(result.Comptes);

            })

        .WithName("GetComptes")
        .Produces<GetComptesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Comptes")
        .WithDescription("Get Comptes");
        }
    }
}
