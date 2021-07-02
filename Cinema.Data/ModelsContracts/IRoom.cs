namespace Cinema.Data.ModelsContracts
{
    using Models;

    using System.Collections.Generic;

    public interface IRoom : IEntity
    {
        Cinema Cinema { get; set; }

        int CinemaId { get; set; }

        int Number { get; set; }

        short SeatsPerRow { get; set; }

        short Rows { get; set; }

        ICollection<Projection> Projections { get; set; }
    }
}
