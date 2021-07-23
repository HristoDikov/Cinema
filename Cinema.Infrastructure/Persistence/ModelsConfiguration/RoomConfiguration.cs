namespace Cinema.Infrastructure.Persistance.ModelsConfiguration
{
    using Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> modelBuilder)
        {
            modelBuilder
                .HasKey(model => model.Id);

            modelBuilder
                .Property(model => model.Number)
                .IsRequired();

            modelBuilder
                .Property(model => model.Rows)
                .IsRequired();

            modelBuilder
                .Property(model => model.SeatsPerRow)
                .IsRequired();

            modelBuilder
                .Property(model => model.CinemaId)
                .IsRequired();
        }
    }
}
