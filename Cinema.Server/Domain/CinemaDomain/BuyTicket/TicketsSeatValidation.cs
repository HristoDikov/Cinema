namespace Cinema.Server.Domain.CinemaDomain.NewTicket
{
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using Repositories.Contracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;
    using Cinema.Server.Data.Dtos;

    public class TicketsSeatValidation : IBuyTicket
    {
        private readonly ISeatRepository seatRepository;
        private readonly IBuyTicket newTicket;

        public TicketsSeatValidation(ISeatRepository seatRepository, IBuyTicket newTicket)
        {
            this.seatRepository = seatRepository;
            this.newTicket = newTicket;
        }

        public async Task<BuyTicketSummary> Buy(ITIcketCreation ticket)
        {
            SeatDto seat = await this.seatRepository.GetSeatByProjIdRowAndCol(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);

            if (seat == null)
            {
                return new BuyTicketSummary(false, $"There is no seat with row number '{ticket.RowNumber}' & col number: '{ticket.ColNumber}'!");
            }

            return await this.newTicket.Buy(ticket);
        }
    }
}
