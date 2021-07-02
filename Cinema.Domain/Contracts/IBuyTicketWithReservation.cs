namespace Cinema.Domain.Contracts
{
    using Models;

    using System.Threading.Tasks;

    public interface IBuyTicketWithReservation
    {
        Task<BuyTicketWithReservationSummary> BuyWithReservation(string uniqueKey);
    }
}
