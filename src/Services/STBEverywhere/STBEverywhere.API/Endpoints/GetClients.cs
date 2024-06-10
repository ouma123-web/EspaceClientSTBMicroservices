using BuildingBlocks.Pagination;
using STBEverywhere.Application.Clients.Queries.GetClients;

namespace STBEverywhere.API.Endpoints
{
    public record GetClientsResponse(PaginatedResult<ClientDto> Clients);
    public class GetClients : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/clients", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetClientsQuery(request));

              //  var response = result.Cliens.Adapt<GetClientsResponse>();

                return Results.Ok(result.Cliens);

            })
        .WithName("GetClients")
        .Produces<GetClientsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Clients")
        .WithDescription("Get Clients");
        }
    }
}
