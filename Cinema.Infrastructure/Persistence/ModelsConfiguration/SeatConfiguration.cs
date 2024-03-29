﻿namespace Cinema.Infrastructure.Persistance.ModelsConfiguration
{
    using Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal sealed class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.RowNum)
                .IsRequired();

            builder
                .Property(s => s.ColNum)
                .IsRequired();

            builder
                .Property(s => s.Booked)
                .IsRequired();

            builder
                .Property(s => s.Bought)
                .IsRequired();

            builder
                .HasOne(s => s.Ticket)
                .WithOne(s => s.Seat)
                .HasForeignKey<Ticket>(t => t.SeatId);
        }
    }
}
