﻿namespace Cinema.Infrastructure.Persistance
{
    using Domain.Entities;
    using Persistance.Models;

    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class CinemaDbContext : IdentityDbContext<User>
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Projection> Projections { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Seat> Seats{ get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Scans a given assembly for all types that implement IEntityTypeConfiguration, and registers each one automatically. 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
