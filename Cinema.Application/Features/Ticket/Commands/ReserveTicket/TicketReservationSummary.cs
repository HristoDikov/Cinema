namespace Cinema.Application.Features.Ticket.Commands.ReserveTicket
{
    using Application.Commons;

    public class TicketReservationSummary : NewSummary
    {
        public TicketReservationSummary(bool isCreated, string msg)
            : base(isCreated, msg)
        {
        }

        public TicketReservationSummary(bool isCreated, string msg, int id)
            : base(isCreated, msg, id)
        {
        }

        public TicketReservationSummary(bool isCreated, string msg, int id, ReservedTicketOutputModel ticketOutputModel)
           : base(isCreated, msg, id)
        {
            this.TicketOutputModel = ticketOutputModel;
        }

        public ReservedTicketOutputModel TicketOutputModel { get; set; }
    }
}
