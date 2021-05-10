namespace Cinema.Server.Data.Models
{
    using ModelsContracts;
    using System.Collections.Generic;

    public class Room : IRoom, IRoomCreation
    {
        public Room(int cinemaId, int number, short seatsPerRow, short rows)
        {
            this.CinemaId = cinemaId;
            this.Number = number;
            this.SeatsPerRow = seatsPerRow;
            this.Rows = rows;

            this.Projections = new HashSet<Projection>();
        }

        public int Id { get; set; }

        public Cinema Cinema { get; set; }
        
        public int CinemaId { get; set; }
        
        public int Number { get; set; }
        
        public short SeatsPerRow { get; set; }
        
        public short Rows { get; set; }
        
        public ICollection<Projection> Projections { get; set; }
    }
}
