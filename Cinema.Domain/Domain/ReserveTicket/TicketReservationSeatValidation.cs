namespace Cinema.Domain.Domain.ReserveTicket
{
    using Models;
    using Contracts;
    using Data.Dtos;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class TicketReservationSeatValidation : ITicketReservation
    {
        private readonly ITicketReservation newTicketReservation;
        private readonly ISeatService seatRepository;

        public TicketReservationSeatValidation(ITicketReservation newTicketReservation, ISeatService seatRepository)
        {
            this.newTicketReservation = newTicketReservation;
            this.seatRepository = seatRepository;
        }

        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            SeatDto seat = await this.seatRepository.GetSeatByProjIdRowAndCol(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);

            if (seat == null)
            {
                return new TicketReservationSummary(false, $"There is no seat on row: '{ticket.RowNumber}' and column: '{ticket.ColNumber}'");
            }

            return await this.newTicketReservation.Reserve(ticket);
        }
    }
}
