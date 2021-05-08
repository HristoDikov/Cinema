namespace Cinema.Server.Data.Models.Contracts
{
    using System.Collections.Generic;

    interface IMovie : IEntity
    {
        string Name { get; set; }

        short DurationMinutes { get; set; }

        ICollection<Projection> Projections { get; set; }
    }
}
