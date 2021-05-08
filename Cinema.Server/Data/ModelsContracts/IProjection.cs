﻿namespace Cinema.Server.Data.Models.Contracts
{
    using System;

    public interface IProjection : IEntity
    {
        Room Room { get; set; }

        int RoomId { get; set; }

        Movie Movie { get; set; }

        int MovieId { get; set; }

        DateTime StartTime { get; set; }
    }
}
