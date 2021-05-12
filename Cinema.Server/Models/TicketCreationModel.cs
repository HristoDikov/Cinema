namespace Cinema.Server.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TicketCreationModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProjectionId { get; set; }

        [Required]
        [Range(1, 100)]
        public short Row{ get; set; }

        [Required]
        [Range(1, 100)]
        public short Col{ get; set; }
    }
}
