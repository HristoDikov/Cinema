﻿namespace Cinema.Server.Domain.CinemaDomainContracts
{
    using Data.ModelsContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public interface ITicketReservation
    {
        Task<TicketReservationSummary> Reserve(ITIcketCreation ticket);
    }
}