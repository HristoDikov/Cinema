namespace Cinema.Server.Data.Models.Contracts
{
    using System;

    public interface ITicket : IEntity
    {
        DateTime ProjectionStartTime { get; set; }

        string MovieName { get; set; }

        string Cinema { get; set; }

        int RoomNumber { get; set; }

        short RowNumber { get; set; }

        short ColNumber { get; set; }

        Guid? UniqueKeyOfReservations { get; set; }

        public int SeatId { get; set; }

        public Seat Seat { get; set; }

    }
}
