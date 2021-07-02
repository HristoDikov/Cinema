namespace Cinema.Data.ModelsConfiguration
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal sealed class ProjectionConfiguration : IEntityTypeConfiguration<Projection>
    {

        public void Configure(EntityTypeBuilder<Projection> modelBuilder)
        {
            modelBuilder
                .HasKey(model => model.Id);

            modelBuilder
                .Property(model => model.MovieId)
                .IsRequired();

            modelBuilder
                .Property(model => model.RoomId)
                .IsRequired();

            modelBuilder
                .Property(model => model.StartTime)
                .IsRequired();

            modelBuilder
                .Property(model => model.AvailableSeats)
                .IsRequired();
        }
    }
}
