namespace Cinema.Server.Data.Models
{
    using ModelsContracts;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Projection : IProjection, IProjectionCreation
    {
        public Projection(int roomId, int movieId, DateTime startTime)
        {
            this.RoomId = roomId;
            this.MovieId = movieId;
            this.StartTime = startTime;

            this.Seats = new HashSet<Seat>();
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        public Room Room { get; set; }

        public int RoomId { get; set; }

        public Movie Movie { get; set; }

        public int MovieId { get; set; }

        public DateTime StartTime { get; set; }

        [Range(0, int.MaxValue)]
        public int AvailableSeats { get; set; }

        public ICollection<Seat> Seats { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
