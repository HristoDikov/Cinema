namespace Cinema.Server.Repositories
{
    using Data.Dtos;
    using Contracts;
    using Cinema.Server.Data;
    using Cinema.Server.Data.Models;
    using Cinema.Server.Models.OutputModels;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class TicketRepository : ITicketRepository
    {
        private readonly CinemaDbContext db;

        public TicketRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<TicketOutputModel> BuyTicket(ProjectionDto projDto, RoomDto roomDto, SeatDto seatDto, string movieName, string cinemaName, short rowNum, short colNum)
        {
            Ticket ticket = new Ticket(DateTime.Parse(projDto.StartTime), movieName, cinemaName, roomDto.Number, rowNum, colNum);

            Seat seat = await this.db.Seats.FirstOrDefaultAsync(s => s.Id == seatDto.Id);
            db.Tickets.Add(ticket);
            seat.Ticket = ticket;
            seat.Bought = true;

            Projection projection = this.db.Projections.FirstOrDefault(p => p.Id == projDto.ProjectionId);
            projection.Tickets.Add(ticket);
            projection.AvailableSeats--;
            await db.SaveChangesAsync();

            TicketOutputModel ticketOutputModel = new TicketOutputModel
            {
                TicketId = ticket.Id,
                CinemaName = ticket.Cinema,
                MovieName = ticket.MovieName,
                ProjectionStartDate = ticket.ProjectionStartTime.ToString("f"),
                RoomNumber = ticket.RoomNumber,
                Row = ticket.RowNumber,
                Column = ticket.ColNumber,
            };

            return ticketOutputModel;
        }
    }
}
