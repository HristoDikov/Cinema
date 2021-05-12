namespace Cinema.Server.Services
{
    using Data;
    using Data.Dtos;
    using Contracts;
    using Data.ModelsContracts;

    using System.Linq;
    using System.Threading.Tasks;
    using Cinema.Server.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class RoomRepository : IRoomRepository
    {
        private readonly CinemaDbContext db;

        public RoomRepository(CinemaDbContext db)
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
