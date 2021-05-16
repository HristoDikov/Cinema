﻿namespace Cinema.Server.Domain.CinemaDomainContracts
{
    using Models;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface IBuyTicket
    {
        Task<BuyTicketSummary> Buy(ITIcketCreation ticket);
    }
}