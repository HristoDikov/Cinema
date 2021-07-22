namespace Cinema.Application.Features.Room.Commands.CreateRoom
{
    using Commons;

    public class CreateRoomSummary : NewSummary
    {
        public CreateRoomSummary(bool isCreated, string msg) 
            : base(isCreated, msg)
        {
        }

        public CreateRoomSummary(bool isCreated, string msg, int id) 
            : base(isCreated, msg, id)
        {
        }
    }
}
