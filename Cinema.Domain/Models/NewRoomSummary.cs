namespace Cinema.Domain.Models
{
    public class NewRoomSummary : NewSummary
    {
        public NewRoomSummary(bool isCreated, string msg) 
            : base(isCreated, msg)
        {
        }

        public NewRoomSummary(bool isCreated, string msg, int id) 
            : base(isCreated, msg, id)
        {
        }
    }
}
