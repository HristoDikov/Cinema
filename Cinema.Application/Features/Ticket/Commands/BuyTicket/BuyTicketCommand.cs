namespace Cinema.Application.Features.Ticket.Commands.BuyTicket
{
    using Domain.Entities;

    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class BuyTicketCommand : IRequest<BuyTicketSummary>
    {
        public int ProjectionId { get; set; }

        public short Row { get; set; }

        public short Col { get; set; }
    }

    public class BuyTicketCommandHandler : IRequestHandler<BuyTicketCommand, BuyTicketSummary> 
    {
        private readonly IBuyTicket buyTicket;

        public BuyTicketCommandHandler(IBuyTicket buyTicket)
        {
            this.buyTicket = buyTicket;
        }

        public async Task<BuyTicketSummary> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
        {
            var summary = await this.buyTicket.Buy(new Ticket(request.ProjectionId, request.Row, request.Col));

            return summary;
        }
    }
}
