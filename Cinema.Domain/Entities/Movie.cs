namespace Cinema.Domain.Entities
{
    using EntitiesContracts;

    using System.Collections.Generic;

    public class Movie : IMovie, IMovieCreation
    {
        public Movie(string name, short DurationMinutes)
        {
            this.Name = name;
            this.DurationMinutes = DurationMinutes;

            this.Projections = new HashSet<Projection>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public short DurationMinutes { get; set; }
        
        public ICollection<Projection> Projections { get; set; }
    }
}
