namespace Cinema.Application.Features.Ticket.Commands.ReserveTicket
{
    using MediatR;

    public class ReserveTicketCommand : IRequest<ReservedTicketOutputModel>
    {
        public int ProjectionId { get; set; }

        public short Row { get; set; }

        public short Col { get; set; }
    }
}
