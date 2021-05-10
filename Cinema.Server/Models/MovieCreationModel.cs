namespace Cinema.Server.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MovieCreationModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [Range(1, 1000)]
        public short DurationMinutes { get; set; }
    }
}
