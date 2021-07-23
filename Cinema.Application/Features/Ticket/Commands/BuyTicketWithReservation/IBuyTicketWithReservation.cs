namespace Cinema.Application.Features.Ticket.Commands.BuyTicketWithReservation
{ 
    using System.Threading.Tasks;

    public interface IBuyTicketWithReservation
    {
        Task<BuyTicketWithReservationSummary> BuyWithReservation(string uniqueKey);
    }
}
