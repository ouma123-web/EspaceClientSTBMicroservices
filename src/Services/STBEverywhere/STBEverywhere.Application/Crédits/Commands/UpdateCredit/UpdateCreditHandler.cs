

namespace STBEverywhere.Application.Crédits.Commands.UpdateCredit
{
    public class UpdateCreditHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateCreditCommand, UpdateCreditResult>
    {

        public async Task<UpdateCreditResult> Handle(UpdateCreditCommand command, CancellationToken cancellationToken)
        {
            var creditId = CreditId.Of(command.Credit.Id);
            var credit = await dbContext.Credits
                .FindAsync([creditId], cancellationToken: cancellationToken);

            if (credit is null)
            {
                throw new CreditNotFoundException(command.Credit.Id);
            }

            UpdateCreditWithNewValues(credit, command.Credit);
            dbContext.Credits.Update(credit);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new UpdateCreditResult(true);
        }

        public void UpdateCreditWithNewValues(Credit credit, CreditDto creditDto)
        {
            credit.Update(
                code: creditDto.Code,
                maxduree: creditDto.MaxDuree,
                maxmontant: creditDto.MaxMontant);
        }


    }
}
