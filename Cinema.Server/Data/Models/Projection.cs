namespace Cinema.Server.Data.Models
{
    using Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Projection : IProjection
    {
        public Projection(int roomId, int movieId, DateTime startTime)
        {
            this.RoomId = roomId;
            this.MovieId = movieId;
            this.StartTime = startTime;

            this.Seats = new HashSet<Seat>();
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
    }
}
