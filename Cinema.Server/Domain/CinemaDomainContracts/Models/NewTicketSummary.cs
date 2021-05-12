using Cinema.Server.Models.OutputModels;

namespace Cinema.Server.Domain.CinemaDomainContracts.Models
{
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

        public NewTicketSummary(bool isCreated, string msg, int id, TicketOutputModel ticketOutputModel)
            : base(isCreated, msg, id)
        {
            this.TicketOutputModel = ticketOutputModel;
        }

        public TicketOutputModel TicketOutputModel{ get; set; }
    }
}
