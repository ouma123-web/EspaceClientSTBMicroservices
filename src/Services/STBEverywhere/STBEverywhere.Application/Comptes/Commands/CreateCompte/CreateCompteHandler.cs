using STBEverywhere.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Comptes.Commands.CreateCompte
{
    public class CreateCompteHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateCompteCommand, CreateCompteResult>
    {

        public async Task<CreateCompteResult> Handle(CreateCompteCommand command, CancellationToken cancellationToken)
        {
            //create Order entity from command object
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
                    id: CompteId.Of(Guid.NewGuid()),
                    opérationId: OpérationId.Of(compteDto.OpérationId),
                    numCompte : compteDto.NumCompte,
                    solde : compteDto.Solde,
                    dateouverture : compteDto.DateOuverture
                    );

            
            return newCompte;
        }

    }
}
