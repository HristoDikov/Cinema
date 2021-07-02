namespace Cinema.Domain.Models
{
    using Cinema.Data.Dtos;

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

        public BuyTicketSummary(bool isCreated, string msg, int id, TicketDto ticket)
            : base(isCreated, msg, id)
        {
            this.Ticket = ticket;
        }

        public TicketDto Ticket{ get; set; }
    }
}
