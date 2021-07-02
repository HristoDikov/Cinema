namespace Cinema.Server.Repositories
{
    using Data;
    using Data.Dtos;
    using Data.Models;

    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class BackgroundService : IHostedService
    {
        public IServiceScopeFactory serviceScopeFactory;
        private Timer timer;

        public BackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.timer = new Timer(CheckForExpiredBookedTickets, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            this.timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void CheckForExpiredBookedTickets(object state)
        {
            using var scope = this.serviceScopeFactory.CreateScope();
            CinemaDbContext db = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();

            //Getting the seats which are booked
            List<SeatWithExpiringTicketDto> seats = db.Seats.Where(t => t.Booked).Select(s => new SeatWithExpiringTicketDto
            {
                SeatId = s.Id,
                Booked = s.Booked,
                ExpirationDate = s.Ticket.ProjectionStartTime.ToString(),
            })
                .ToList();

            //Getting the Ids of the seats with expired tickets.
            List<int> seatsIDs = seats.Where(s => (DateTime.Parse(s.ExpirationDate) - DateTime.Now).TotalMinutes < 10)
                .Select(s => s.SeatId)
                .ToList();


            foreach (var seatId in seatsIDs)
            {   
                //Cancelling the reservation
                Seat seat = db.Seats.Where(s => s.Id == seatId).FirstOrDefault();
                seat.Booked = false;

                //Removing the ticket with that reservation
                Ticket ticket = db.Tickets.Where(t => t.SeatId == seatId).FirstOrDefault();
                db.Tickets.Remove(ticket);

                //Updating the projection available seats count
                Projection projection = db.Projections.Where(p => p.Id == seat.ProjectionId).FirstOrDefault();
                projection.AvailableSeats++;

                db.SaveChanges();
            }
        }
    }
}
