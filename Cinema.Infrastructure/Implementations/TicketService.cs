//namespace Cinema.Infrastructure.Implementations
//{
//    using Data;
//    using Data.Dtos;
//    using Contracts;
//    using Data.Models;

//    using System;
//    using System.Linq;
//    using System.Threading.Tasks;
//    using Microsoft.EntityFrameworkCore;

//    public class TicketService : ITicketService
//    {
//        private readonly CinemaDbContext db;

//        public TicketService(CinemaDbContext db)
//        {
//            this.db = db;
//        }

//        public async Task<TicketDto> BuyTicket(ProjectionDto projDto, RoomDto roomDto, SeatDto seatDto, string movieName, string cinemaName, short rowNum, short colNum)
//        {
//            Ticket ticket = new Ticket(DateTime.Parse(projDto.StartTime), movieName, cinemaName, roomDto.Number, rowNum, colNum, seatDto.Id);

//            await this.SetSeatTicketBooked(seatDto.Id, ticket);

//            await this.DecreaseProjectionAvailableSeats(projDto.ProjectionId, ticket);

//            await db.SaveChangesAsync();

//            TicketDto ticketOutputModel = new TicketDto
//            {
//                TicketId = ticket.Id,
//                CinemaName = ticket.Cinema,
//                MovieName = ticket.MovieName,
//                ProjectionStartDate = ticket.ProjectionStartTime.ToString("f"),
//                RoomNumber = ticket.RoomNumber,
//                Row = ticket.RowNumber,
//                Column = ticket.ColNumber,
//            };

//            return ticketOutputModel;
//        }

//        public async Task<TicketReservationDto> ReserveTicket(ProjectionDto projDto, RoomDto roomDto, SeatDto seatDto, string movieName, string cinemaName, short rowNum, short colNum)
//        {
//            Ticket ticket = new Ticket(Guid.NewGuid(), DateTime.Parse(projDto.StartTime), movieName, cinemaName, roomDto.Number, rowNum, colNum, seatDto.Id);

//            await this.SetSeatTicketBooked(seatDto.Id, ticket);

//            await this.DecreaseProjectionAvailableSeats(projDto.ProjectionId, ticket);

//            await this.db.SaveChangesAsync();

//            return CreateTicketDto(ticket);
//        }

//        public async Task<TicketDto> GenerateBoughtTicket(string uniqueKey) 
//        {
//            Guid guid = Guid.Parse(uniqueKey);

//            TicketDto ticketDto = await this.db.Tickets.Where(t => t.UniqueKeyOfReservations == guid)
//              .Select(t => new TicketDto
//              {
//                  TicketId = t.Id,
//                  MovieName = t.MovieName,
//                  CinemaName = t.Cinema,
//                  ProjectionStartDate = t.ProjectionStartTime.ToString(),
//                  RoomNumber = t.RoomNumber,
//                  Row = t.RowNumber,
//                  Column = t.ColNumber,
//              })
//              .FirstOrDefaultAsync();

//            return ticketDto;
//        }

//        public async Task<int> GetTicketProjectionId(string uniqueKey) 
//        {
//            Guid guid = Guid.Parse(uniqueKey);

//            return await this.db.Tickets
//                .Where(t => t.UniqueKeyOfReservations == guid)
//                .Select(t => t.ProjectionId)
//                .FirstOrDefaultAsync();
//        }

//        public async Task<TicketProjIdRowAndColDto> GetTicketIdRowAndCol(string uniqueKey)
//        {
//            Guid guid = Guid.Parse(uniqueKey);

//            return await this.db.Tickets
//                .Where(t => t.UniqueKeyOfReservations == guid)
//                .Select(t => new TicketProjIdRowAndColDto 
//                {
//                ProjId = t.ProjectionId,
//                Row = t.RowNumber,
//                Col = t.ColNumber,
//                })
//                .FirstOrDefaultAsync();
//        }

//        public async Task<int> GetTicketId(string uniqueKey)
//        {
//            Guid guid = Guid.Parse(uniqueKey);

//            return await this.db.Tickets
//                .Where(t => t.UniqueKeyOfReservations == guid)
//                .Select(t => t.Id)
//                .FirstOrDefaultAsync();
//        }

//        private async Task SetSeatTicketBooked(int seatId, Ticket ticket)
//        {
//            Seat seat = await db.Seats.FirstOrDefaultAsync(s => s.Id == seatId);
//            seat.Ticket = ticket;
//            seat.Booked = true;
//        }

//        private async Task DecreaseProjectionAvailableSeats(int projId, Ticket ticket) 
//        {
//            Projection proj = await db.Projections.FirstOrDefaultAsync(p => p.Id == projId);
//            proj.Tickets.Add(ticket);
//            proj.AvailableSeats--;
//        }


//        private TicketReservationDto CreateTicketDto(Ticket ticket)
//        {
//            return new TicketReservationDto
//            {
//                Id = ticket.Id,
//                UniqueKeyOfReservations = ticket.UniqueKeyOfReservations.ToString(),
//                CinemaName = ticket.Cinema,
//                MovieName = ticket.MovieName,
//                ProjectionStartDate = ticket.ProjectionStartTime.ToString("f"),
//                RoomNumber = ticket.RoomNumber,
//                Row = ticket.RowNumber,
//                Column = ticket.ColNumber,
//            };
//        }
//    }
//}
