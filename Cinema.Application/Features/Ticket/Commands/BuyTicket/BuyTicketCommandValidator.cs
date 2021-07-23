namespace Cinema.Application.Features.Ticket.Commands.BuyTicket
{
    using FluentValidation;

    public class BuyTicketCommandValidator : AbstractValidator<BuyTicketCommand>
    {
        private const int MinProjId = 1;
        private const int MinRowNum = 1;
        private const int MinColNum = 1;

        public BuyTicketCommandValidator() 
        {
            RuleFor(t => t.ProjectionId)
                .NotNull()
                .Must(p => p >= MinProjId)
                .WithMessage("Projection id should be 1 or greater!");

            RuleFor(t => t.Row)
                .NotNull()
                .Must(r => r >= MinRowNum)
                .WithMessage("Row must be 1 or greater!");


            RuleFor(t => t.Col)
                .NotNull()
                .Must(c => c >= MinColNum)
                .WithMessage("Column must be 1 or greater!");
        }
    }
}
