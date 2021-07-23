namespace Cinema.Application.Features.Ticket.Commands.ReserveTicket
{
    using Domain.Entities;

    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ReserveTicketCommand : IRequest<TicketReservationSummary>
    {
        public int ProjectionId { get; set; }

        public short Row { get; set; }

        public short Col { get; set; }
    }

    public class ReserveTicketCommandHandler : IRequestHandler<ReserveTicketCommand, TicketReservationSummary>
    {
        private readonly ITicketReservation ticketReservation;

        public ReserveTicketCommandHandler(ITicketReservation ticketReservation)
        {
            this.ticketReservation = ticketReservation;
        }

        public async Task<TicketReservationSummary> Handle(ReserveTicketCommand request, CancellationToken cancellationToken)
        {
            var summary = await this.ticketReservation.Reserve(new Ticket(request.ProjectionId, request.Row, request.Col));

            return summary;
        }
    }
}
