namespace Cinema.Application.Features.Seat
{
   public class SeatWithExpiringTicketOutputModel
    {
        public int SeatId { get; set; }

        public bool Booked { get; set; }

        public string ExpirationDate { get; set; }
    }
}
