namespace Cinema.Domain.Models
{
    using Data.Dtos;

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

        public BuyTicketWithReservationSummary(bool isCreated, string msg, int id, TicketDto ticket)
          : base(isCreated, msg, id)
        {
            this.Ticket = ticket;
        }

        public TicketDto Ticket { get; set; }
    }
}
