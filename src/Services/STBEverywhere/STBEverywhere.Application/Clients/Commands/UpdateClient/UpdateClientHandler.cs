


namespace STBEverywhere.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientHandler(IApplicationDbContext dbContext)
        : ICommandHandler<UpdateClientCommand, UpdateClientResult>
    {
        public async Task<UpdateClientResult> Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            //Update entity from command object
            //save to database
            //return result

            var clientId = ClientId.Of(command.Client.ClientId);
            var client = await dbContext.Clients
                .FindAsync([clientId], cancellationToken: cancellationToken);

            if (client is null)
            {
                throw new ClientNotFoundException(command.Client.ClientId);
            }


            UpdateClientWithNewValues(client, command.Client);

            dbContext.Clients.Update(client);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateClientResult(true);

        }

        public void UpdateClientWithNewValues(Client client, ClientDto clientDto)
        {
            client.Update(
                nom: clientDto.Nom,
                prenom : clientDto.Prenom,
                adresse: clientDto.Adresse,
                email: clientDto.Email,
                téléphone: clientDto.Téléphone);

        }
    }
    
}
