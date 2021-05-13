namespace Cinema.Server.Domain.CinemaDomain.BuyTicketWithReservation
{
    using Cinema.Server.Data.Dtos;
    using Cinema.Server.Repositories.Contracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class BuyTicketWithReservationNotBoughtValidation : IBuyTicketWithReservation
    {
        private readonly IBuyTicketWithReservation buyTicketWithReservation;
        private readonly ITicketRepository ticketRepository;
        private readonly ISeatRepository seatRepository;

        public BuyTicketWithReservationNotBoughtValidation(IBuyTicketWithReservation buyTicketWithReservation, ITicketRepository ticketRepository, ISeatRepository seatRepository)
        {
            this.buyTicketWithReservation = buyTicketWithReservation;
            this.ticketRepository = ticketRepository;
            this.seatRepository = seatRepository;
        }

        public async Task<BuyTicketWithReservationSummary> BuyWithReservation(string uniqueKey)
        {
            TicketProjIdRowAndColDto ticketModel = await this.ticketRepository.GetTicketIdRowAndCol(uniqueKey);
            bool isBought = await this.seatRepository.CheckIfSeatIsBought(ticketModel.ProjId, ticketModel.Row, ticketModel.Col);

            if (isBought)
            {
                return new BuyTicketWithReservationSummary(false, "This ticket has already been bought!");
            }

            return await this.buyTicketWithReservation.BuyWithReservation(uniqueKey);
        }
    }
}
