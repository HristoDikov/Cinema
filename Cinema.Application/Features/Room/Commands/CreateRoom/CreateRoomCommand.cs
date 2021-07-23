namespace Cinema.Application.Features.Room.Commands.CreateRoom
{
    using Domain.Entities;

    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateRoomCommand : IRequest<CreateRoomSummary>
    {
        public int CinemaId { get; set; }

        public int Number { get; set; }

        public short SeatsPerRow { get; set; }

        public short Rows { get; set; }
    }

    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, CreateRoomSummary> 
    {
        private readonly ICreateRoom createRoom;

        public CreateRoomCommandHandler(ICreateRoom createRoom)
        {
            this.createRoom = createRoom;
        }

        public async Task<CreateRoomSummary> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var summary = await this.createRoom.Create(new Room(request.CinemaId, request.Number, request.SeatsPerRow, request.Rows));

            return summary;
        }
    }
}
