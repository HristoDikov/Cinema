namespace Cinema.Domain.EntitiesContracts
{
    public interface IMovieCreation
    {
        string Name { get; set; }

        short DurationMinutes { get; set; }
    }
}
