namespace Cinema.Application.Features.Movie.Commands.CreateMovie
{
    using Commons;

    public class CreateMovieSummary : NewSummary
    {
        public CreateMovieSummary(bool isCreated, string msg) 
            : base(isCreated, msg)
        {
        }

        public CreateMovieSummary(bool isCreated, string msg, int id) 
            : base(isCreated, msg, id)
        {
        }
    }
}
