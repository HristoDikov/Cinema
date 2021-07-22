namespace Cinema.Application.Features.Projection.Commands.CreateProjection
{
    using System;

    public class ProjectionOutputModel
    {
        public int ProjectionId { get; set; }

        public DateTime StartTime { get; set; }

        public int RoomId { get; set; }

        public int MovieId { get; set; }
    }
}
