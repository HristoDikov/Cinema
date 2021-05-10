namespace Cinema.Server.Domain.CinemaDomainContracts.Models
{
    public class NewMovieSummary : NewSummary
    {
        public NewMovieSummary(bool isCreated, string msg) 
            : base(isCreated, msg)
        {
        }

        public NewMovieSummary(bool isCreated, string msg, int id) 
            : base(isCreated, msg, id)
        {
        }
    }
}
