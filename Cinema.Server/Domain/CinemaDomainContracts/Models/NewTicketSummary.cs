namespace Cinema.Server.Domain.CinemaDomainContracts.Models
{
    using Data.Dtos;

    public class NewTicketSummary : NewSummary
    {
        public NewTicketSummary(bool isCreated, string msg) 
            : base(isCreated, msg)
        {
        }
        

        public NewTicketSummary(bool isCreated, string msg, int id) 
            : base(isCreated, msg, id)
        {
        }

        public NewTicketSummary(bool isCreated, string msg, int id, TicketDto ticket)
            : base(isCreated, msg, id)
        {
            this.Ticket = ticket;
        }

        public TicketDto Ticket{ get; set; }
    }
}
