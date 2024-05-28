
using STBEverywhere.Application.Comptes.Queries.GetComptesByOpération;

namespace STBEverywhere.API.Endpoints
{

    public record GetComptesByOpérationResponse(IEnumerable<CompteDto> Comptes);
    public class GetComptesByOpération : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/comptes/opération/{opérationId}", async (Guid opérationId, ISender sender) =>
            {
                var result = await sender.Send(new GetComptesByOpérationQuery(opérationId));

                var response = result.Adapt<GetComptesByOpérationResponse>();

                return Results.Ok(response);
            })

                
                
        .WithName("GetComptesByOpération")
        .Produces<GetComptesByOpérationResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Comptes By Opération")
        .WithDescription("Get Comptes By Opération");
        }
    }
}
