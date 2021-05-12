namespace Cinema.Server.Domain.CinemaDomain.NewTicket
{
    using Services.Contracts;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;
    using Cinema.Server.Data.Dtos;

    public class NewTicketRoomValidation : INewTicket
    {
        private readonly IRoomRepository roomRepository;
        private readonly IProjectionRepository projectionRepository;
        private readonly INewTicket newTicket;

        public NewTicketRoomValidation(IRoomRepository roomRepository, INewTicket newTicket, IProjectionRepository projectionRepository)
        {
            this.roomRepository = roomRepository;
            this.projectionRepository = projectionRepository;
            this.newTicket = newTicket;
        }

        public async Task<NewTicketSummary> New(ITIcketCreation ticket)
        {
            ProjectionDto proj = await this.projectionRepository.GetById(ticket.ProjectionId);
            RoomDto room = await this.roomRepository.GetById(proj.RoomId);

            if (room == null)
            {
                return new NewTicketSummary(false, $"Room with Id: '{room.Id}' does not exist!");
            }

            return await this.newTicket.New(ticket);
        }
    }
}
