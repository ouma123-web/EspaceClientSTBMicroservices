using BuildingBlocks.Pagination;
using STBEverywhere.Application.Clients.Queries.GetClients;
using STBEverywhere.Application.Crédits.Queries.GetCrédits;

namespace STBEverywhere.API.Endpoints
{
    public record GetCreditsResponse(PaginatedResult<CreditDto> Credits);
    public class GetCredits : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/crédits", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetCréditsQuery(request));

                //  var response = result.Cliens.Adapt<GetClientsResponse>();

                return Results.Ok(result.Credits);

            })
        .WithName("GetCrédits")
        .Produces<GetCreditsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Crédits")
        .WithDescription("Get Crédits");
        }
    }
}
