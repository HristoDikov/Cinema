namespace Cinema.Domain.Domain.ReserveTicket
{
    using Models;
    using Contracts;
    using Data.Dtos;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class TicketReservationRoomValidation : ITicketReservation
    {
        private readonly IRoomService roomService;
        private readonly IProjectionService projectionService;
        private readonly ITicketReservation newTicketReservation;

        public TicketReservationRoomValidation(IRoomService roomService, ITicketReservation newTicketReservation, IProjectionService projectionService)
        {
            this.roomService = roomService;
            this.projectionService = projectionService;
            this.newTicketReservation = newTicketReservation;
        }

        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            ProjectionDto proj = await this.projectionService.GetById(ticket.ProjectionId);
            RoomDto room = await this.roomService.GetById(proj.RoomId);

            if (room == null)
            {
                return new TicketReservationSummary(false, $"Room with Id: '{room.Id}' does not exist!");
            }

            return await this.newTicketReservation.Reserve(ticket);
        }
    }
}
