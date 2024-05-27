

namespace STBEverywhere.Application.Comptes.Commands.CreateCompte
{
    public class CreateCompteHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateCompteCommand, CreateCompteResult>
    {

        public async Task<CreateCompteResult> Handle(CreateCompteCommand command, CancellationToken cancellationToken)
        {
            //create COMPTE entity from command object
            //save to database
            //return result 

            var compte = CreateNewCompte(command.Compte);

            dbContext.Comptes.Add(compte);
            await dbContext.SaveChangesAsync(cancellationToken);

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
}
