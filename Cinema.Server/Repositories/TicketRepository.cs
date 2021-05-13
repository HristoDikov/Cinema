namespace Cinema.Server.Repositories
{
    using Data;
    using Data.Dtos;
    using Contracts;
    using Data.Models;
    using Models.OutputModels;

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
            Ticket ticket = new Ticket(DateTime.Parse(projDto.StartTime), movieName, cinemaName, roomDto.Number, rowNum, colNum,seatDto.Id);


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

        public async Task<TicketReservationDto> ReserveTicket(ProjectionDto projDto, RoomDto roomDto, SeatDto seatDto, string movieName, string cinemaName, short rowNum, short colNum) 
        {
            Ticket ticket = new Ticket(Guid.NewGuid(), DateTime.Parse(projDto.StartTime), movieName, cinemaName, roomDto.Number, rowNum, colNum, seatDto.Id);

            await this.SetSeatTicketBooked(seatDto.Id, ticket);

            await this.DecreaseProjectionAvailableSeats(projDto.ProjectionId, ticket);

            await this.db.SaveChangesAsync();

            return CreateTicketDto(ticket);
        }

        private async Task SetSeatTicketBooked(int seatId, Ticket ticket)
        {
            Seat seat = await db.Seats.FirstOrDefaultAsync(s => s.Id == seatId);
            seat.Ticket = ticket;
            seat.Booked = true;
        }

        private async Task DecreaseProjectionAvailableSeats(int projId, Ticket ticket) 
        {
            Projection proj = await db.Projections.FirstOrDefaultAsync(p => p.Id == projId);
            proj.Tickets.Add(ticket);
            proj.AvailableSeats--;
        }


        private TicketReservationDto CreateTicketDto(Ticket ticket)
        {
            return new TicketReservationDto
            {
                Id = ticket.Id,
                UniqueKeyOfReservations = ticket.UniqueKeyOfReservations.ToString(),
                CinemaName = ticket.Cinema,
                MovieName = ticket.MovieName,
                ProjectionStartDate = ticket.ProjectionStartTime.ToString("f"),
                RoomNumber = ticket.RoomNumber,
                Row = ticket.RowNumber,
                Column = ticket.ColNumber,
            };
        }
    }
}
