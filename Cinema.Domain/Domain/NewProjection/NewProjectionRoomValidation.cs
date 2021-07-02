namespace Cinema.Domain.Domain.NewProjection
{
    using Models;
    using Contracts;
    using Data.Dtos;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class NewProjectionRoomValidation : INewProjection
    {
        private readonly IRoomService roomService;
        private readonly INewProjection newProj;

        public NewProjectionRoomValidation(IRoomService roomService, INewProjection newProj)
        {
            this.roomService = roomService;
            this.newProj = newProj;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation proj)
        {
            RoomDto room = await roomService.GetById(proj.RoomId);

            if (room == null)
            {
                return new NewProjectionSummary(false, $"Room with id: '{proj.RoomId}' does not exist!");
            }

            return await newProj.New(proj);
        }
    }
}
