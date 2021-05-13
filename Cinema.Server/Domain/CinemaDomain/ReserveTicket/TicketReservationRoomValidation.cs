namespace Cinema.Server.Domain.CinemaDomain.ReserveTicket
{
    using Data.Dtos;
    using Data.ModelsContracts;
    using Repositories.Contracts;
    using Domain.CinemaDomainContracts;
    using Domain.CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class TicketReservationRoomValidation : ITicketReservation
    {
        private readonly IRoomRepository roomRepository;
        private readonly IProjectionRepository projectionRepository;
        private readonly ITicketReservation newTicketReservation;

        public TicketReservationRoomValidation(IRoomRepository roomRepository, ITicketReservation newTicketReservation, IProjectionRepository projectionRepository)
        {
            this.roomRepository = roomRepository;
            this.projectionRepository = projectionRepository;
            this.newTicketReservation = newTicketReservation;
        }

        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            ProjectionDto proj = await this.projectionRepository.GetById(ticket.ProjectionId);
            RoomDto room = await this.roomRepository.GetById(proj.RoomId);

            if (room == null)
            {
                return new TicketReservationSummary(false, $"Room with Id: '{room.Id}' does not exist!");
            }

            return await this.newTicketReservation.Reserve(ticket);
        }
    }
}
