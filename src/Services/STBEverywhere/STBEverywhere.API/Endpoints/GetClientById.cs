
using STBEverywhere.Application.Clients.Queries.GetClientsById;

namespace STBEverywhere.API.Endpoints
{

    public record GetClientByIdResponse(IEnumerable<ClientDto> Clients);
    public class GetClientById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/clients/{id}", async (int idClient, ISender sender) =>
            {
                var result = await sender.Send(new GetClientsByIdQuery(idClient));

                var response = result.Adapt<GetClientByIdResponse>();

                return Results.Ok(response);
            })

        .WithName("GetClientsByName")
        .Produces<GetClientByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Clients By Id")
        .WithDescription("Get Clients By Id");
        }
    }
}
