namespace Cinema.Server.Domain.CinemaDomain.NewTicket
{
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using Repositories.Contracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class TicketsSeatIsNotBoughtOrBookedValidation : IBuyTicket
    {
        private readonly ISeatRepository seatRepository;
        private readonly IBuyTicket newTicket;
        public TicketsSeatIsNotBoughtOrBookedValidation(ISeatRepository seatRepository, IBuyTicket newTicket)
        {
            this.seatRepository = seatRepository;
            this.newTicket = newTicket;
        }
        public async Task<BuyTicketSummary> Buy(ITIcketCreation ticket)
        {
            bool isBooked = await this.seatRepository.CheckIfSeatIsBooked(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);
            bool isBought = await this.seatRepository.CheckIfSeatIsBought(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);

            if (isBooked)
            {
                return new BuyTicketSummary(false, "This seat was already booked!");
            }

            if (isBought)
            {
                return new BuyTicketSummary(false, "This seat was already bought!");
            }

            return await this.newTicket.Buy(ticket);
        }
    }
}
