namespace Cinema.Application.Features.Ticket.Commands.ReserveTicket
{
    public class ReservedTicketOutputModel
    {
        public int Id { get; set; }

        public string UniqueKeyOfReservations { get; set; }

        public string ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNumber { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }
    }
}
