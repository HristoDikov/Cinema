namespace Cinema.Server.Models.OutputModels
{
    public class RoomOutputModel
    {
        public int Id { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int Number { get; set; }

        public short Rows { get; set; }

        public short SeatsPerRow { get; set; }
    }
}
