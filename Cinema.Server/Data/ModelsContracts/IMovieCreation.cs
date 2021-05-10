namespace Cinema.Server.Data.ModelsContracts
{
    public interface IMovieCreation
    {
        string Name { get; set; }

        short DurationMinutes { get; set; }
    }
}
