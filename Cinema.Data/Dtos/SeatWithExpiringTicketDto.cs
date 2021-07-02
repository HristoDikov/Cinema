namespace Cinema.Data.Dtos
{
    public class SeatWithExpiringTicketDto
    {
        public int SeatId { get; set; }

        public bool Booked { get; set; }

        public string ExpirationDate { get; set; }
    }
}
