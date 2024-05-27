using Carter;
using Mapster;
using MediatR;
using STBEverywhere.Application.Comptes.Commands.CreateCompte;
using STBEverywhere.Application.Dtos;

namespace STBEverywhere.API.Endpoints
{

    public record CreateCompteRequest(CompteDto Compte);

    public record CreateCompteResponse(Guid Id);
    public class CreateCompte : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/comptes", async(CreateCompteRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateCompteCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateCompteResponse>();

                return Results.Created($"/comptes/{response.Id}", response);
            })

        .WithName("CreateCompte")
        .Produces<CreateCompteResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Compte")
        .WithDescription("Create Compte");
        }
    }
}
