namespace Cinema.Server.Data.ModelsContracts
{
    public interface ITIcketCreation
    {
        int ProjectionId { get; set; }

        short RowNumber { get; set; }

        short ColNumber { get; set; }
    }
}
