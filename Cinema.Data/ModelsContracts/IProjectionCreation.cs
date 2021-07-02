namespace Cinema.Data.ModelsContracts
{
    using System;

    public interface IProjectionCreation
    {
        int RoomId { get; }

        int MovieId { get; }

        DateTime StartTime { get; }
    }
}
