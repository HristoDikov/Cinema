namespace Cinema.Server.Domain.CinemaDomainContracts
{
    using Models;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface INewTicket
    {
        Task<NewTicketSummary> New(ITIcketCreation ticket);
    }
}
