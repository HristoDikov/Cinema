﻿namespace Cinema.Server.Repositories.Contracts
{
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface ICinemaRepository
    {
        Task<int> Create(ICinemaCreation model);

        Task<ICinema> GetByNameAndAddress(string name, string address);

        Task<ICinema> GetById(int id);

        Task<string> GetCinemaName(int cinemaId);
    }
}