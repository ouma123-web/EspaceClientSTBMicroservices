using FluentValidation;


namespace STBEverywhere.Application.Comptes.Commands.CreateCompte
{
    public record CreateCompteCommand(CompteDto Compte)
        : ICommand<CreateCompteResult>;


    public record CreateCompteResult(Guid Id);

    public class CreateCompteCommandValidator : AbstractValidator<CreateCompteCommand>
    {
        public CreateCompteCommandValidator()
        {
            RuleFor(x => x.Compte.OpérationId).NotNull().WithMessage("OpérationId is required");
        }
    }


}
