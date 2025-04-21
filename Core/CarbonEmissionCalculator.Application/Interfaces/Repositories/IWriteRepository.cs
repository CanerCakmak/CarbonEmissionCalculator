using CarbonEmissionCalculator.Domain.Common;

namespace CarbonEmissionCalculator.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);

        Task<T> UpdateAsync(T entity);

        Task SoftDeleteByIdAsync(int id);
        Task SoftDeleteAsync(T entity);
        Task SoftDeleteRangeAsync(IList<T> entities);

        Task HardDeleteByIdAsync(int id);
        Task HardDeleteAsync(T entity);
        Task HardDeleteRangeAsync(IList<T> entities);


    }
}
