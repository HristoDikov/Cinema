namespace Cinema.Infrastructure.Persistance.ModelsConfiguration
{
    using Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal sealed class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> modelBuilder)
        {
            modelBuilder
                .HasKey(model => model.Id);

            modelBuilder
                .Property(model => model.Name)
                .IsRequired();

            modelBuilder
                .Property(model => model.Address)
                .IsRequired();
        }
    }
}
