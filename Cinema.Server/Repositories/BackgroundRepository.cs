namespace Cinema.Server.Repositories
{
    using Cinema.Server.Data;
    using Cinema.Server.Data.Dtos;
    using Cinema.Server.Data.Models;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class BackgroundRepository : IHostedService
    {
        public IServiceScopeFactory serviceScopeFactory;
        private Timer timer;

        public BackgroundRepository(IServiceScopeFactory serviceScopeFactory)
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
