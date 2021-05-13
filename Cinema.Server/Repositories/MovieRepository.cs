namespace Cinema.Server.Repositories
{
    using Data;
    using Contracts;
    using Data.Models;
    using Data.ModelsContracts;

    using System.Linq;
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
            await this.db.SaveChangesAsync();

            return newMovie.Id;
        }

        public async Task<IMovie> GetById(int movieId)
        {
            return await this.db.Movies
                .FirstOrDefaultAsync(m => m.Id == movieId);
        }

        public async Task<string> GetMovieName(int movieId)
        {
            return await this.db.Movies.Where(m => m.Id == movieId)
                .Select(m => m.Name)
                .FirstOrDefaultAsync();
        }
    }
}
