using Cinema.Server.Models.OutputModels;

namespace Cinema.Server.Domain.CinemaDomainContracts.Models
{
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

        public BuyTicketWithReservationSummary(bool isCreated, string msg, int id, TicketOutputModel ticket)
          : base(isCreated, msg, id)
        {
            this.Ticket = ticket;
        }

        public TicketOutputModel Ticket { get; set; }
    }
}
