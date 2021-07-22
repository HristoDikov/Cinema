namespace Cinema.Domain.Entities
{
    using EntitiesContracts;

    using System;

    public class Ticket : ITicket, ITIcketCreation
    {
        public Ticket()
        {

        }

        public Ticket(int projectionId,  short rowNumber, short colNumber)
        {
            this.ProjectionId = projectionId;
            this.RowNumber = rowNumber;
            this.ColNumber = colNumber;
        }

        public Ticket(DateTime projectionStartTime, string movieName, string cinema, int roomNumber, short rowNumber, short colNumber, int seatId)
        {
            this.ProjectionStartTime = projectionStartTime;
            this.MovieName = movieName;
            this.Cinema = cinema;
            this.RoomNumber = roomNumber;
            this.RowNumber = rowNumber;
            this.ColNumber = colNumber;
            this.SeatId = seatId;
        }

        public Ticket(Guid uniqueKeyOfReservation, DateTime projectionStartTime, string movieName, string cinema, int roomNumber, short rowNumber, short colNumber, int seatId)
        {
            this.UniqueKeyOfReservations = uniqueKeyOfReservation; 
            this.ProjectionStartTime = projectionStartTime;
            this.MovieName = movieName;
            this.Cinema = cinema;
            this.RoomNumber = roomNumber;
            this.RowNumber = rowNumber;
            this.ColNumber = colNumber;
            this.SeatId = seatId;
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

        public int ProjectionId { get; set; }

        public Projection Projection { get; set; }
    }
}
