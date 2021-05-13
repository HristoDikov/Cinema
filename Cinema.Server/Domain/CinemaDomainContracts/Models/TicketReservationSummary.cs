namespace Cinema.Server.Domain.CinemaDomainContracts.Models
{
    using Data.Dtos;

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

        public TicketReservationSummary(bool isCreated, string msg, int id, TicketReservationDto ticketOutputModel)
           : base(isCreated, msg, id)
        {
            this.TicketOutputModel = ticketOutputModel;
        }

        public TicketReservationDto TicketOutputModel { get; set; }
    }
}
