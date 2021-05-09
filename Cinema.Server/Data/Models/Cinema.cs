namespace Cinema.Server.Data.Models
{
    using Data.Models.Contracts;

    using System.Collections.Generic;

    public class Cinema : ICinema, ICinemaCreation
    {

        public Cinema(string name, string address)
        {
            this.Name = name;
            this.Address = address;
            this.Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; } 

        public ICollection<Room> Rooms { get; set; }
    }
}
