namespace Cinema.Application.Features.Room.Commands.CreateRoom
{
    using System.Threading.Tasks;
    using Domain.EntitiesContracts;

    public interface ICreateRoom
    {
        Task<CreateRoomSummary> Create(IRoomCreation room);
    }
}
