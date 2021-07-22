namespace Cinema.Domain.EntitiesContracts
{
    using System;

    public interface IProjectionCreation
    {
        int RoomId { get; }

        int MovieId { get; }

        DateTime StartTime { get; }
    }
}
