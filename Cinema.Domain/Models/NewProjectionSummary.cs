namespace Cinema.Domain.Models
{
    public class NewProjectionSummary : NewSummary
    {
        public NewProjectionSummary(bool isCreated, string msg) 
            : base(isCreated, msg)
        {
        }

        public NewProjectionSummary(bool isCreated, string msg, int id) 
            : base(isCreated, msg, id)
        {
        }
    }
}
