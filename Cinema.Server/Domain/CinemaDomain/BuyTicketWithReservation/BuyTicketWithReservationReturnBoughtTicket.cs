namespace Cinema.Server.Domain.CinemaDomain.BuyTicketWithReservation
{
    using Models.OutputModels;
    using CinemaDomainContracts;
    using Repositories.Contracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class BuyTicketWithReservationReturnBoughtTicket : IBuyTicketWithReservation
    {
        private readonly ITicketRepository ticketReservation;

        public BuyTicketWithReservationReturnBoughtTicket(ITicketRepository ticketReservation)
        {
            this.ticketReservation = ticketReservation;
        }

        public async Task<BuyTicketWithReservationSummary> BuyWithReservation(string uniqueKey)
        {
            TicketOutputModel ticket = await this.ticketReservation.GenerateBoughtTicket(uniqueKey);

            return new BuyTicketWithReservationSummary(true, $"The reserved ticket was bought!", ticket.TicketId, ticket);
        }
    }
}
