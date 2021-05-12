namespace Cinema.Server.Data.ModelsConfiguration
{
    using Cinema.Server.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal sealed class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.ProjectionStartTime)
                .IsRequired();

            builder
                .Property(t => t.MovieName)
                .IsRequired();

            builder
                .Property(t => t.Cinema)
                .IsRequired();

            builder
                .Property(t => t.RoomNumber)
                .IsRequired();

            builder
                .Property(t => t.RowNumber)
                .IsRequired();

            builder
                .Property(t => t.ColNumber)
                .IsRequired();

            builder
                .Property(t => t.UniqueKeyOfReservations);

            builder
              .HasOne(t => t.Seat)
              .WithOne(t => t.Ticket)
              .HasForeignKey<Seat>(s => s.TicketId);
        }
    }
}
