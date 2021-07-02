namespace Cinema.Domain.Contracts
{
    using Models;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface INewRoom
    {
        Task<NewRoomSummary> New(IRoomCreation room);
    }
}
