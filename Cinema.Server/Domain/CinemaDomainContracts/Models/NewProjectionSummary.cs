namespace Cinema.Server.Domain.CinemaDomainContracts.Models
{
    public class NewProjectionSummary
    {
        public NewProjectionSummary(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public NewProjectionSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }
    }
}
