using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application.Crédits.Commands.UpdateCredit
{
    public record UpdateCreditCommand(CreditDto Credit)
        : ICommand<UpdateCreditResult>;
    

    public record UpdateCreditResult(bool IsSuccess);

    public class UpdateCreditCommandValidator : AbstractValidator<UpdateCreditCommand>
    {
        public UpdateCreditCommandValidator()
        {
            RuleFor(x => x.Credit.Id).NotEmpty().WithMessage("Id is required");

        }
    }
}
