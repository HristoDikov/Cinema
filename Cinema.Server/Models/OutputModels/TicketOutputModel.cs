namespace Cinema.Server.Models.OutputModels
{
    public class TicketOutputModel
    {
        public int TicketId { get; set; }

        public string ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNumber { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }
    }

}
