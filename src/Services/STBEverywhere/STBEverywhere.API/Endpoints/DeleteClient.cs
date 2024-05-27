
using STBEverywhere.Application.Clients.Commands.DeleteClient;

namespace STBEverywhere.API.Endpoints
{

    public record DeleteClientResponse(bool IsSuccess);
    public class DeleteClient : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/clients/{id}", async(Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteClientCommand(Id));

                var response = result.Adapt<DeleteClientResponse>();

                return Results.Ok(response);
            })

        .WithName("DeleteClient")
        .Produces<DeleteClientResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Client")
        .WithDescription("Delete Client");
        }
    }
}
