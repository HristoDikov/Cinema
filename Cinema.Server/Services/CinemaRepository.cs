namespace Cinema.Server.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Data.ModelsContracts;
    using System.Linq;
    using Data.Models;
    using Contracts;
    using Data;

    public class CinemaRepository : ICinemaRepository
    {
        private readonly CinemaDbContext db;

        public CinemaRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(ICinemaCreation model)
        {
            Cinema newCinema = new Cinema(model.Name, model.Address);

            db.Cinemas.Add(newCinema);

            await db.SaveChangesAsync();

            return newCinema.Id;
        }

        public async Task<ICinema> GetById(int id)
        {
            return await db.Cinemas
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ICinema> GetByNameAndAddress(string name, string address)
        {
            return await db.Cinemas
                             .Where(c => c.Name == name && c.Address == address)
                             .FirstOrDefaultAsync();
        }
        public async Task<string> GetCinemaName(int cinemaId)
        {
            return await db.Cinemas
                             .Where(c => c.Id == cinemaId)
                             .Select(c => c.Name).FirstOrDefaultAsync();
        }

    }
}
