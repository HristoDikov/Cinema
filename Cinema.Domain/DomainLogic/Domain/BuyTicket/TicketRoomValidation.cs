//namespace Domain.DomainLogic.Domain.BuyTicket
//{
//    using Models;
//    using Data.Dtos;
//    using Contracts;
//    using Data.ModelsContracts;
//    using Cinema.Services.Contracts;

//    using System.Threading.Tasks;

//    public class TicketRoomValidation : IBuyTicket
//    {
//        private readonly IRoomService roomService;
//        private readonly IProjectionService projectionService;
//        private readonly IBuyTicket newTicket;

//        public TicketRoomValidation(IRoomService roomRepository, IBuyTicket newTicket, IProjectionService projectionService)
//        {
//            this.roomService = roomRepository;
//            this.projectionService = projectionService;
//            this.newTicket = newTicket;
//        }

//        public async Task<BuyTicketSummary> Buy(ITIcketCreation ticket)
//        {
//            ProjectionDto proj = await this.projectionService.GetById(ticket.ProjectionId);
//            RoomDto room = await this.roomService.GetById(proj.RoomId);

//            if (room == null)
//            {
//                return new BuyTicketSummary(false, $"Room with Id: '{room.Id}' does not exist!");
//            }

//            return await this.newTicket.Buy(ticket);
//        }
//    }
//}
