namespace Cinema.Application.Features.Ticket.Commands.BuyTicketWithReservation
{
    using Commons;
    using Commands.BuyTicket;

    public class BuyTicketWithReservationSummary : NewSummary
    {
        public BuyTicketWithReservationSummary(bool isCreated, string msg)
            : base(isCreated, msg)
        {
        }

        public BuyTicketWithReservationSummary(bool isCreated, string msg, int id)
            : base(isCreated, msg, id)
        {
        }

        public BuyTicketWithReservationSummary(bool isCreated, string msg, int id, BoughtTicketOutputModel ticket)
          : base(isCreated, msg, id)
        {
            this.Ticket = ticket;
        }

        public BoughtTicketOutputModel Ticket { get; set; }
    }
}
