namespace Cinema.Server.Domain.CinemaDomain.NewTicket
{
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using Repositories.Contracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;
    using Cinema.Server.Data.Dtos;

    public class TicketRoomValidation : IBuyTicket
    {
        private readonly IRoomRepository roomRepository;
        private readonly IProjectionRepository projectionRepository;
        private readonly IBuyTicket newTicket;

        public TicketRoomValidation(IRoomRepository roomRepository, IBuyTicket newTicket, IProjectionRepository projectionRepository)
        {
            this.roomRepository = roomRepository;
            this.projectionRepository = projectionRepository;
            this.newTicket = newTicket;
        }

        public async Task<BuyTicketSummary> Buy(ITIcketCreation ticket)
        {
            ProjectionDto proj = await this.projectionRepository.GetById(ticket.ProjectionId);
            RoomDto room = await this.roomRepository.GetById(proj.RoomId);

            if (room == null)
            {
                return new BuyTicketSummary(false, $"Room with Id: '{room.Id}' does not exist!");
            }

            return await this.newTicket.Buy(ticket);
        }
    }
}
