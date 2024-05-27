
using STBEverywhere.Application.Clients.Commands.UpdateClient;

namespace STBEverywhere.API.Endpoints
{

    public record UpdateClientRequest(ClientDto Client);

    public record UpdateClientResponse(bool IsSuccess);
    public class UpdateClient : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/clients", async (UpdateClientRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateClientCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateClientResponse>();
                return Results.Ok(response);
            })

        .WithName("UpdateClient")
        .Produces<UpdateClientResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Client")
        .WithDescription("Update Client");
        }
    }
}
