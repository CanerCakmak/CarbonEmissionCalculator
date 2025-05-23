﻿using CarbonEmissionCalculator.Application.Interfaces.Repositories;
using CarbonEmissionCalculator.Domain.Common;

namespace CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : BaseEntity, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity, new();
        Task<int> SaveAsync();
        int Save();
    }
}
