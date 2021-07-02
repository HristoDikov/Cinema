namespace Cinema.Services.Implementations
{
    using Data;
    using Contracts;
    using Data.Dtos;
    using Data.Models;
    using Data.ModelsContracts;

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

        public async Task<IRoom> GetByCinemaAndNumber(int cinemaId, int number)
        {
            return await this.db.Rooms
                .FirstOrDefaultAsync(x => x.CinemaId == cinemaId &&
                                               x.Number == number);
        }

        public async Task<RoomDto> GetById(int roomId)
        {
            return await this.db.Rooms
                .Where(r => r.Id == roomId)
                .Select(r => new RoomDto
                {
                    Id = r.Id,
                    Number = r.Number,
                    CinemaId = r.CinemaId
                })
                .FirstOrDefaultAsync();
        }
    }
}
