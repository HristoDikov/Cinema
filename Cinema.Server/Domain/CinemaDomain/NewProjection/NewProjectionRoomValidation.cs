namespace Cinema.Server.Domain.CinemaDomain.NewProjection
{
    using Data.Dtos;
    using Services.Contracts;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class NewProjectionRoomValidation : INewProjection
    {
        private readonly IRoomRepository roomRepo;
        private readonly INewProjection newProj;

        public NewProjectionRoomValidation(IRoomRepository roomRepo, INewProjection newProj)
        {
            this.roomRepo = roomRepo;
            this.newProj = newProj;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation proj)
        {
            RoomDto room = await roomRepo.GetById(proj.RoomId);

            if (room == null)
            {
                return new NewProjectionSummary(false, $"Room with id: '{proj.RoomId}' does not exist!");
            }

            return await newProj.New(proj);
        }
    }
}
