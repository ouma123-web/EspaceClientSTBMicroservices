

using Microsoft.EntityFrameworkCore;

namespace STBEverywhere.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientHandler(IApplicationDbContext dbContext)
        : ICommandHandler<DeleteClientCommand, DeleteClientResult>

    {
        public async Task<DeleteClientResult> Handle(DeleteClientCommand command, CancellationToken cancellationToken)
        {

            //Delete entity from command object
            //save to database
            //return result

            var clientId = ClientId.Of(command.ClientId);
            var client = await dbContext.Clients
                .FindAsync([clientId], cancellationToken: cancellationToken);

            if (client is null)
            {
                throw new ClientNotFoundException(command.ClientId);
            }

            dbContext.Clients.Remove(client);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new DeleteClientResult(true);


        }
    }
}
