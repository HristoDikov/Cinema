namespace Cinema.Server.Domain.CinemaDomain.BuyTicketWithReservation
{
    using CinemaDomainContracts;
    using Repositories.Contracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class BuyTicketWithReservation : IBuyTicketWithReservation
    {
        private readonly ISeatRepository seatRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly IBuyTicketWithReservation buyTicketWithReservation;

        public BuyTicketWithReservation(ISeatRepository seatRepository, IBuyTicketWithReservation buyTicketWithReservation, ITicketRepository ticketRepository)
        {
            this.seatRepository = seatRepository;
            this.buyTicketWithReservation = buyTicketWithReservation;
            this.ticketRepository = ticketRepository;
        }

        public async Task<BuyTicketWithReservationSummary> BuyWithReservation(string uniqueKey)
        {
            int ticket = await this.ticketRepository.GetTicketId(uniqueKey);
            await this.seatRepository.SetSeatToBought(ticket);

            return await this.buyTicketWithReservation.BuyWithReservation(uniqueKey);
        }
    }
}
