namespace Cinema.Application.Features.Cinema.Commands.CreateCinema
{
    using Commons;

    public class CreateCinemaSummary : NewSummary
    {
        public CreateCinemaSummary(bool isCreated, string msg) 
            : base(isCreated, msg)
        {
        }

        public CreateCinemaSummary(bool isCreated, string msg, int id) 
            : base(isCreated, msg, id)
        {
        }
    }
}
