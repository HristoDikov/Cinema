﻿namespace Cinema.Server.Data.ModelsContracts
{
    public interface IRoomCreation
    {
        int CinemaId { get; set; }

        int Number { get; set; }

        short SeatsPerRow { get; set; }

        short Rows { get; set; }
    }
}
