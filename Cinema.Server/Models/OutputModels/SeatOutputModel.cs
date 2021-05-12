namespace Cinema.Server.Models.OutputModels
{
    public class SeatOutputModel
    {
        public int Id { get; set; }

        public short RowNum { get; set; }

        public short ColNum { get; set; }

        public bool Booked { get; set; }

        public bool Bought { get; set; }
    }
}
