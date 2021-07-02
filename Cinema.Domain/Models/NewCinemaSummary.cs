namespace Cinema.Domain.Models
{
    public class NewCinemaSummary : NewSummary
    {
        public NewCinemaSummary(bool isCreated, string msg) 
            : base(isCreated, msg)
        {
        }

        public NewCinemaSummary(bool isCreated, string msg, int id) 
            : base(isCreated, msg, id)
        {
        }
    }
}
