﻿namespace Cinema.Server.Data.ModelsContracts
{
    using Models;
    using System.Collections.Generic;

    public interface IMovie : IEntity
    {
        string Name { get; set; }

        short DurationMinutes { get; set; }

        ICollection<Projection> Projections { get; set; }
    }
}
