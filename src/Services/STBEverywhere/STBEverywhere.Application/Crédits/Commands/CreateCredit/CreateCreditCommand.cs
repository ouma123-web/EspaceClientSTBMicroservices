using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Crédits.Commands.CreateCredit
{
    
        public record CreateCreditCommand(CreditDto Credit)
        : ICommand<CreateCreditResult>;


    public record CreateCreditResult(Guid Id);

    public class CreateCreditCommandValidator : AbstractValidator<CreateCreditCommand>
    {
        public CreateCreditCommandValidator()
        {

            RuleFor(x => x.Credit.CreditClients).NotNull().WithMessage("CreditClients is required");
        }
    }

}
