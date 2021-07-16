namespace Cinema.Server.Models
{
    using Infrastructure.Attributes;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProjectionCreationModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int RoomId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int MovieId { get; set; }

        [Required]
        [Date]   // Custom filter
        public DateTime StartTime { get; set; }
    }
}
