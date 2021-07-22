namespace Cinema.Infrastructure.Persistance.ModelsConfiguration
{
    using Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> modelBuilder)
        {
            modelBuilder
                .HasKey(model => model.Id);

            modelBuilder
                .Property(model => model.Name)
                .IsRequired();

            modelBuilder
                .Property(model => model.DurationMinutes)
                .IsRequired();
        }
    }
}
