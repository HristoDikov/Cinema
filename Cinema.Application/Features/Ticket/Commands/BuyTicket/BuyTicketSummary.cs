namespace Cinema.Application.Features.Ticket.Commands.BuyTicket
{
    using Application.Commons;

    public class BuyTicketSummary : NewSummary
    {
        public BuyTicketSummary(bool isCreated, string msg)
            : base(isCreated, msg)
        {
        }


        public BuyTicketSummary(bool isCreated, string msg, int id)
            : base(isCreated, msg, id)
        {
        }

        public BuyTicketSummary(bool isCreated, string msg, int id, BoughtTicketOutputModel ticket)
            : base(isCreated, msg, id)
        {
            this.Ticket = ticket;
        }

        public BoughtTicketOutputModel Ticket { get; set; }
    }
}
