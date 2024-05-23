

using FluentValidation;

namespace STBEverywhere.Application.Clients.Commands.DeleteClient
{
    public record DeleteClientCommand(Guid ClientId)
        : ICommand<DeleteClientResult>;

    public record DeleteClientResult(bool IsSuccess);

    public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
    {
        public DeleteClientCommandValidator()
        {
            RuleFor(x => x.ClientId).NotEmpty().WithMessage("ClientId is required");
        }
    }
}
