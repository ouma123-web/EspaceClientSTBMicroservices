using STBEverywhere.Application.Comptes.Commands.CreateCompte;
using STBEverywhere.Application.Crédits.Commands.CreateCredit;

namespace STBEverywhere.API.Endpoints
{
    public record CreateCreditRequest(CreditDto Credit);

    public record CreateCreditResponse(Guid Id);
    public class CreateCredit : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/crédit", async(CreateCreditRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateCreditCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateCreditResponse>();

                return Results.Created($"/crédit/{response.Id}", response);
            })

        .WithName("CreateCrédit")
        .Produces<CreateCreditResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Crédit")
        .WithDescription("Create Crédit");
        }
    }
}
