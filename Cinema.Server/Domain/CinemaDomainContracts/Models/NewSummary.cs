namespace Cinema.Server.Domain.CinemaDomainContracts.Models
{
    public abstract class NewSummary
    {
        public NewSummary(bool isCreated, string msg)
        {
            this.IsCreated = isCreated;
            this.Message = msg;
        }

        public NewSummary(bool isCreated, string msg, int id)
            : this(isCreated, msg)
        {
            this.Id = id;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }

        public int Id { get; set; }
    }
}
