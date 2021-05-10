namespace Cinema.Server.Services
{
    using Data;
    using Contracts;
    using Data.Models;
    using Data.ModelsContracts;

    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext db;

        public MovieRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<IMovie> GetByNameAndDuration(string name, short duration)
        {
            return await this.db.Movies
                .FirstOrDefaultAsync(m => m.Name == name &&
                                                m.DurationMinutes == duration);
        }

        public async Task<int> Create(IMovieCreation movie)
        {
            Movie newMovie = new Movie(movie.Name, movie.DurationMinutes);

            db.Movies.Add(newMovie);
            await db.SaveChangesAsync();

            return newMovie.Id;
        }
    }
}
