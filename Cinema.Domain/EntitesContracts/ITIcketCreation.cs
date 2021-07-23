namespace Cinema.Domain.EntitiesContracts
{
    public interface ITIcketCreation
    {
        int ProjectionId { get; set; }

        short RowNumber { get; set; }

        short ColNumber { get; set; }
    }
}
