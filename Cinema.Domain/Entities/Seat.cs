namespace Cinema.Domain.Entities
{
    using EntitiesContracts;

    public class Seat : ISeat
    {
        public Seat(short rowNum, short colNum, int projectionId)
        {
            this.RowNum = rowNum;
            this.ColNum = colNum;
            this.ProjectionId = projectionId;
        }

        public int Id { get; set; }
        
        public short RowNum { get; set; }
        
        public short ColNum { get; set; }
        
        public bool Booked { get; set; }
        
        public bool Bought { get; set; }
        
        public int ProjectionId { get; set; }

        public Projection Projection { get; set; }

        public int? TicketId { get; set; }

        public Ticket Ticket { get; set; }
        
    }
}
