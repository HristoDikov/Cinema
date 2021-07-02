namespace Cinema.Domain.Contracts
{
    using Models;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface ITicketReservation
    {
        Task<TicketReservationSummary> Reserve(ITIcketCreation ticket);
    }
}
