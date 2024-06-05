

using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using STBEverywhere.Domain.Models;
using System.Text;
using System.Threading.Channels;
using IModel = RabbitMQ.Client.IModel;

namespace STBEverywhere.Application.Comptes.Commands.CreateCompte
{
    public class CreateCompteHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateCompteCommand, CreateCompteResult>
    {
        private readonly IModel _channel;


       /* public CreateCompteHandler(RabbitMQService rabbitMQService)
        {
            _channel = rabbitMQService.GetChannel();
        }*/

        public async Task<CreateCompteResult> Handle(CreateCompteCommand command, CancellationToken cancellationToken)
        {
            //create COMPTE entity from command object
            //save to database
            //return result 

            var compte = CreateNewCompte(command.Compte);

            dbContext.Comptes.Add(compte);
            await dbContext.SaveChangesAsync(cancellationToken);

            // get client by id client
            Client c1 = new Client();
            c1 = dbContext.Clients.FirstOrDefault(c => c.Id == compte.ClientId);

            var message = $"{c1.Email},{compte.Id}";
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: "registration_queue", basicProperties: null, body: body);
            Console.WriteLine($"Sent message: {message}");



            return new CreateCompteResult(compte.Id.Value);
        }

        private Compte CreateNewCompte(CompteDto compteDto)
        {

            var newCompte = Compte.Create(
                    compteId: CompteId.Of(Guid.NewGuid()),
                    opérationId: OpérationId.Of(compteDto.OpérationId),
                    clientId: ClientId.Of(compteDto.ClientId),
                    numCompte: compteDto.NumCompte,
                    solde: compteDto.Solde,
                    dateouverture: compteDto.DateOuverture
                    ) ;

            
            return newCompte;
        }

    }



    public class RabbitMQService : IDisposable
    {
        private readonly IModel _channel;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq",
                UserName = "guest",
                Password = "guest"
            };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }

        public IModel GetChannel() => _channel;
    }
}
