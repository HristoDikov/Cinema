namespace Cinema.Application.Features.Ticket.Commands.ReserveTicket
{
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public interface ITicketReservation
    {
        Task<TicketReservationSummary> Reserve(ITIcketCreation ticket);
    }
}
