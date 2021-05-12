namespace Cinema.Server.Models.OutputModels
{
    using System;
    using System.Collections.Generic;

    public class ProjectionOutputModel
    {
        public long Id { get; set; }

        public string MovieName { get; set; }

        public DateTime StartTime { get; set; }

        public int RoomId { get; set; }

        public ICollection<SeatOutputModel> Seats { get; set; }

    }
}
