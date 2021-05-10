namespace Cinema.Server.Data.ModelsContracts
{
    using Cinema.Server.Data.Models;
    using System.Collections.Generic;

    public interface ICinema : IEntity  
    {
        string Name { get; set; }

        string Address { get; set; }

        ICollection<Room> Rooms { get; set; }
    }
}
