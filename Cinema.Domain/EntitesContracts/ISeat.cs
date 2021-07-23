namespace Cinema.Domain.EntitiesContracts
{
    using Entities;

    public interface ISeat : IEntity
    {
        short RowNum { get; set; }

        short ColNum { get; set; }

        bool Booked { get; set; }

        bool Bought { get; set; }

        public int ProjectionId { get; set; }

        Projection Projection { get; set; }

        public int? TicketId { get; set; }

        Ticket Ticket { get; set; }
    }
}
