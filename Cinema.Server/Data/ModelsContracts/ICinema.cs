namespace Cinema.Server.Data.Models.Contracts
{
    using System.Collections.Generic;

    public interface ICinema : IEntity  
    {
        string Name { get; set; }

        string Address { get; set; }

        ICollection<Room> Rooms { get; set; }
    }
}
