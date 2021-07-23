namespace Cinema.Infrastructure.Implementations
{

    using Persistance;
    using Domain.Entities;
    using Application.Seat;
    using Application.Contracts.Services;
    using Application.Features.Ticket.Commands.Common;
    using Application.Features.Room.Commands.CreateRoom;
    using Application.Features.Ticket.Commands.BuyTicket;
    using Application.Features.Ticket.Commands.ReserveTicket;
    using Application.Features.Projection.Commands.CreateProjection;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class TicketService : ITicketService
    {
        private readonly CinemaDbContext db;

        public TicketService(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<BoughtTicketOutputModel> BuyTicket(ProjectionOutputModel projOutputModel, RoomOutputModel roomOutputModel, SeatOutputModel seatOutputModel, string movieName, string cinemaName, short rowNum, short colNum)
        {
            Ticket ticket = new Ticket(projOutputModel.StartTime, movieName, cinemaName, roomOutputModel.Number, rowNum, colNum, seatOutputModel.Id);

            await this.SetSeatTicketBooked(seatOutputModel.Id, ticket);

            await this.DecreaseProjectionAvailableSeats(projOutputModel.ProjectionId, ticket);

            await db.SaveChangesAsync();

            BoughtTicketOutputModel ticketOutputModel = new BoughtTicketOutputModel
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

        public async Task<ReservedTicketOutputModel> ReserveTicket(ProjectionOutputModel projDto, RoomOutputModel roomDto, SeatOutputModel seatDto, string movieName, string cinemaName, short rowNum, short colNum)
        {
            Ticket ticket = new Ticket(Guid.NewGuid(), projDto.StartTime, movieName, cinemaName, roomDto.Number, rowNum, colNum, seatDto.Id);

            await this.SetSeatTicketBooked(seatDto.Id, ticket);

            await this.DecreaseProjectionAvailableSeats(projDto.ProjectionId, ticket);

            await this.db.SaveChangesAsync();

            return CreateTicketDto(ticket);
        }

        public async Task<BoughtTicketOutputModel> GenerateBoughtTicket(string uniqueKey)
        {
            Guid guid = Guid.Parse(uniqueKey);

            BoughtTicketOutputModel ticketDto = await this.db.Tickets.Where(t => t.UniqueKeyOfReservations == guid)
              .Select(t => new BoughtTicketOutputModel
              {
                  TicketId = t.Id,
                  MovieName = t.MovieName,
                  CinemaName = t.Cinema,
                  ProjectionStartDate = t.ProjectionStartTime.ToString(),
                  RoomNumber = t.RoomNumber,
                  Row = t.RowNumber,
                  Column = t.ColNumber,
              })
              .FirstOrDefaultAsync();

            return ticketDto;
        }

        public async Task<int> GetTicketProjectionId(string uniqueKey)
        {
            Guid guid = Guid.Parse(uniqueKey);

            return await this.db.Tickets
                .Where(t => t.UniqueKeyOfReservations == guid)
                .Select(t => t.ProjectionId)
                .FirstOrDefaultAsync();
        }

        public async Task<TicketProjIdRowAndColOutputModel> GetTicketIdRowAndCol(string uniqueKey)
        {
            Guid guid = Guid.Parse(uniqueKey);

            return await this.db.Tickets
                .Where(t => t.UniqueKeyOfReservations == guid)
                .Select(t => new TicketProjIdRowAndColOutputModel
                {
                    ProjId = t.ProjectionId,
                    Row = t.RowNumber,
                    Col = t.ColNumber,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetTicketId(string uniqueKey)
        {
            Guid guid = Guid.Parse(uniqueKey);

            return await this.db.Tickets
                .Where(t => t.UniqueKeyOfReservations == guid)
                .Select(t => t.Id)
                .FirstOrDefaultAsync();
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


        private ReservedTicketOutputModel CreateTicketDto(Ticket ticket)
        {
            return new ReservedTicketOutputModel
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
