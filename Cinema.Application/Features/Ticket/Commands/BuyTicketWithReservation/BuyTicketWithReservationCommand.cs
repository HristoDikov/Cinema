namespace Cinema.Application.Features.Ticket.Commands.BuyTicketWithReservation
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class BuyTicketWithReservationCommand : IRequest<BuyTicketWithReservationSummary>
    {
        public string uniqueKey { get; set; }

    }

    public class BuyTicketWithReservationCommandHandler : IRequestHandler<BuyTicketWithReservationCommand, BuyTicketWithReservationSummary>
    {
        private readonly IBuyTicketWithReservation buyTicketWithReservation;

        public BuyTicketWithReservationCommandHandler(IBuyTicketWithReservation buyTicketWithReservation)
        {
            this.buyTicketWithReservation = buyTicketWithReservation;
        }

        public async Task<BuyTicketWithReservationSummary> Handle(BuyTicketWithReservationCommand request, CancellationToken cancellationToken)
        {
            var summary = await this.buyTicketWithReservation.BuyWithReservation(request.uniqueKey);

            return summary;
        }
    }
}
