using BuildingBlocks.Pagination;
using STBEverywhere.Application.Clients.Queries.GetClients;
using STBEverywhere.Application.Opérations.Queries.GetOpérations;

namespace STBEverywhere.API.Endpoints
{
    public record GetOpérationResponse(PaginatedResult<OpérationDto> Opérations);
    public class GetOpérations : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/opérations", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetOpérationsQuery(request));

                //  var response = result.Cliens.Adapt<GetClientsResponse>();

                return Results.Ok(result.Opérations);

            })
        .WithName("GetOpérations")
        .Produces<GetClientsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Opérations")
        .WithDescription("Get Opérations");
        }

    }
}
