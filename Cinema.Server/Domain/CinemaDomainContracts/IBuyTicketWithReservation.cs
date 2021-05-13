namespace Cinema.Server.Domain.CinemaDomainContracts
{
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public interface IBuyTicketWithReservation
    {
        Task<BuyTicketWithReservationSummary> BuyWithReservation(string uniqueKey);
    }
}
