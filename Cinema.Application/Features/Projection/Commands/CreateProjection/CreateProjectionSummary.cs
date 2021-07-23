namespace Cinema.Application.Features.Projection.Commands.CreateProjection
{
    using Commons;

    public class CreateProjectionSummary : NewSummary
    {
        public CreateProjectionSummary(bool isCreated, string msg) 
            : base(isCreated, msg)
        {
        }

        public CreateProjectionSummary(bool isCreated, string msg, int id) 
            : base(isCreated, msg, id)
        {
        }
    }
}
