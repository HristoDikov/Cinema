namespace Cinema.Infrastructure.Implementations
{
    using Persistance;
    using Domain.Entities;
    using Domain.EntitiesContracts;
    using Application.Contracts.Services;
    using Application.Features.Room.Commands.CreateRoom;

    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class RoomService : IRoomService
    {
        private readonly CinemaDbContext db;

        public RoomService(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(IRoomCreation room)
        {
            Room newRoom = new Room(room.CinemaId, room.Number, room.SeatsPerRow, room.Rows);

            this.db.Rooms.Add(newRoom);
            await this.db.SaveChangesAsync();

            return newRoom.Id;
        }

        public async Task<RoomOutputModel> GetByCinemaAndNumber(int cinemaId, int number)
        {
            return await this.db.Rooms.
                Where(r => r.CinemaId == cinemaId && r.Number == number)
                .Select(r => new RoomOutputModel 
                { 
                    Id = r.Id,
                    CinemaId = r.CinemaId,
                    Number  = r.Number
                })
                .FirstOrDefaultAsync();
        }

        public async Task<RoomOutputModel> GetById(int roomId)
        {
            return await this.db.Rooms
                .Where(r => r.Id == roomId)
                .Select(r => new RoomOutputModel
                {
                    Id = r.Id,
                    Number = r.Number,
                    CinemaId = r.CinemaId
                })
                .FirstOrDefaultAsync();
        }
    }
}
