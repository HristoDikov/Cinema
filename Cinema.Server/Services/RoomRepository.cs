namespace Cinema.Server.Services
{
    using Data.ModelsContracts;
    using Data;

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

            db.Rooms.Add(newRoom);
            await this.db.SaveChangesAsync();

            return newRoom.Id;
        }

        public async Task<IRoom> GetByCinemaAndNumber(int cinemaId, int number)
        {
            return await db.Rooms.FirstOrDefaultAsync(x => x.CinemaId == cinemaId &&
                                               x.Number == number);
        }
    }
}
