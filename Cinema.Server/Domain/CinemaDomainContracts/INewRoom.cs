namespace Cinema.Server.Domain.CinemaDomainContracts
{
    using Data.ModelsContracts;
    using Models;

    using System.Threading.Tasks;

    public interface INewRoom
    {
        Task<NewRoomSummary> New(IRoomCreation room);
    }
}
