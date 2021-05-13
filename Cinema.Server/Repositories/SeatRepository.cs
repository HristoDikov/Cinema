﻿namespace Cinema.Server.Repositories
{
    using Data;
    using Data.Dtos;
    using Contracts;
    using Data.Models;
    using Data.ModelsContracts;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class SeatRepository : ISeatRepository
    {
        private readonly CinemaDbContext db;

        public SeatRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task CreateSeats(IProjectionCreation projection)
        {
            IRoom room = this.db.Rooms.FirstOrDefault(r => r.Id == projection.RoomId);

            int projectionId = this.db.Projections
                .Where(p => p.RoomId == room.Id && p.StartTime == projection.StartTime)
                .Select(p => p.Id)
                .FirstOrDefault();

            List<ISeat> seats = new List<ISeat>();

            for (short i = 1; i <= room.Rows; i++)
            {
                for (short j = 1; j <= room.SeatsPerRow; j++)
                {
                    Seat seat = new Seat(i, j, projectionId);

                    seats.Add(seat);
                    this.db.Seats.Add(seat);
                }
            }

            await this.db.SaveChangesAsync();
        }

        public async Task<SeatDto> GetSeatByProjIdRowAndCol(int projId, short row, short col)
        {
            return await this.db.Seats
                .Where(s => s.ProjectionId == projId && s.RowNum == row && s.ColNum == col)
                .Select(s => new SeatDto
                {
                    Id = s.Id,
                    IsBooked = s.Booked,
                    IsBought = s.Bought
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CheckIfSeatIsBooked(int projId, short row, short col) 
        {
            SeatDto seat = await this.GetSeatByProjIdRowAndCol(projId, row, col);

            if (seat.IsBooked)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> CheckIfSeatIsBought(int projId, short row, short col)
        {
            SeatDto seat = await this.GetSeatByProjIdRowAndCol(projId, row, col);

            if (seat.IsBought)
            {
                return true;
            }

            return false;
        }
    }
}