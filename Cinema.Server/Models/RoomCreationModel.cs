namespace Cinema.Server.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RoomCreationModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "CinemaId should be a positive number!")]
        public int CinemaId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Number should be a positive number!")]
        public int Number { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seats per row should be a positive number!")]
        public short SeatsPerRow { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Rows should be a positive number!")]
        public short Rows { get; set; }
    }
}
