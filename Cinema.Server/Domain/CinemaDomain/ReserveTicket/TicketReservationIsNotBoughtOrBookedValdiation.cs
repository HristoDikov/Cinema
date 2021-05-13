namespace Cinema.Server.Domain.CinemaDomain.ReserveTicket
{
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using System.Threading.Tasks;
    using Repositories.Contracts;
    using CinemaDomainContracts.Models;

    public class TicketReservationIsNotBoughtOrBookedValdiation : ITicketReservation
    {
        private readonly ISeatRepository seatRepository;
        private readonly ITicketReservation newTicketReservation;
        public TicketReservationIsNotBoughtOrBookedValdiation(ISeatRepository seatRepository, ITicketReservation newTicketReservation)
        {
            this.seatRepository = seatRepository;
            this.newTicketReservation = newTicketReservation;
        }
        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            bool isBooked = await this.seatRepository.CheckIfSeatIsBooked(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);
            bool isBought = await this.seatRepository.CheckIfSeatIsBought(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);

            if (isBooked)
            {
                return new TicketReservationSummary(false, "This seat was already booked!");
            }

            if (isBought)
            {
                return new TicketReservationSummary(false, "This seat was already bought!");
            }

            return await this.newTicketReservation.Reserve(ticket);
        }
    }
}
