using STBEverywhere.Application.Comptes.Commands.CreateCompte;
using STBEverywhere.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Crédits.Commands.CreateCredit
{
   
        public class CreateCreditHandler(IApplicationDbContext dbContext)
               : ICommandHandler<CreateCreditCommand, CreateCreditResult>
    {

        public async Task<CreateCreditResult> Handle(CreateCreditCommand command, CancellationToken cancellationToken)
        {
            //create Credit entity from command object
            //save to database
            //return result 

            var credit = CreateNewCredit(command.Credit);

            dbContext.Credits.Add(credit);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateCreditResult(credit.Id.Value);
        }



        private Credit CreateNewCredit(CreditDto creditDto)
        {

            var newCredit = Credit.Create(
                    creditId: CreditId.Of(Guid.NewGuid()),
                    code: creditDto.Code,
                    maxmontant: creditDto.MaxMontant,
                    maxduree: creditDto.MaxDuree
                    );

          /*  foreach (var creditClientDto in creditDto.CreditClients)
            {
                newCredit.Add(ClientId.Of(creditClientDto.ClientId), creditClientDto.DateDeblocage, creditClientDto MontantDebloquer);
            }*/


            return newCredit;
        }

    }
}
