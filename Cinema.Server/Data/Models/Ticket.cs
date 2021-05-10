namespace Cinema.Server.Data.Models
{
    using ModelsContracts;
    using System;

    public class Ticket : ITicket
    {
        public Ticket(DateTime projectionStartTime, string movieName, string cinema, int roomNumber, short rowNumber, short colNumber)
        {
            this.ProjectionStartTime = projectionStartTime;
            this.MovieName = movieName;
            this.Cinema = cinema;
            this.RoomNumber = roomNumber;
            this.RowNumber = rowNumber;
            this.ColNumber = ColNumber;
        }

        public int Id { get; set; }

        public DateTime ProjectionStartTime { get; set; }

        public string MovieName { get; set; }
        
        public string Cinema { get; set; }
        
        public int RoomNumber { get; set; }
        
        public short RowNumber { get; set; }
        
        public short ColNumber { get; set; }
        
        public Guid? UniqueKeyOfReservations { get; set; }
        
        public int SeatId { get; set; }
        
        public Seat Seat { get; set; }   
    }
}
