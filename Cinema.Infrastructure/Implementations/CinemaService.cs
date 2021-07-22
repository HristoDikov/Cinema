namespace Cinema.Infrastructure.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Application.Contracts.Services;
    using Persistance;
    using Application.Features.Cinema.Commands.CreateCinema;
    using Domain.EntitiesContracts;
    using Domain.Entities;

    public class CinemaService : ICinemaService
    {
        private readonly CinemaDbContext db;

        public CinemaService(CinemaDbContext db)
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

        public async Task<CinemaOutputModel> GetById(int id)
        {
            return await db.Cinemas
                .Where(c => c.Id == id)
                .Select(c => new CinemaOutputModel
                {
                    Name = c.Name,
                    Address = c.Address,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CinemaOutputModel> GetByNameAndAddress(string name, string address)
        {
            return await db.Cinemas
                             .Where(c => c.Name == name && c.Address == address)
                             .Select(c => new CinemaOutputModel
                             {
                                 Name = c.Name,
                                 Address = c.Address,
                             })
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
