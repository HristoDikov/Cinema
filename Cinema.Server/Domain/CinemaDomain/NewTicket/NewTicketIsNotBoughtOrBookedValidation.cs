namespace Cinema.Server.Domain.CinemaDomain.NewTicket
{
    using Data.ModelsContracts;
    using Services.Contracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class NewTicketIsNotBoughtOrBookedValidation : INewTicket
    {
        private readonly ISeatRepository seatRepository;
        private readonly INewTicket newTicket;
        public NewTicketIsNotBoughtOrBookedValidation(ISeatRepository seatRepository, INewTicket newTicket)
        {
            this.seatRepository = seatRepository;
            this.newTicket = newTicket;
        }
        public async Task<NewTicketSummary> New(ITIcketCreation ticket)
        {
            bool isBooked = await this.seatRepository.CheckIfSeatIsBooked(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);
            bool isBought = await this.seatRepository.CheckIfSeatIsBought(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);

            if (isBooked)
            {
                return new NewTicketSummary(false, "This seat was already booked!");
            }

            if (isBought)
            {
                return new NewTicketSummary(false, "This seat was already bought!");
            }

            return await this.newTicket.New(ticket);
        }
    }
}
