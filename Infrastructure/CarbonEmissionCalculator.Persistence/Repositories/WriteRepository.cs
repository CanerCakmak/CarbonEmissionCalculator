using CarbonEmissionCalculator.Application.Interfaces.Repositories;
using CarbonEmissionCalculator.Domain.Common;
using CarbonEmissionCalculator.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarbonEmissionCalculator.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;

        public WriteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private DbSet<T> Table { get => _appDbContext.Set<T>(); }
        public async Task AddAsync(T entity)
            => await Table.AddAsync(entity);

        public async Task AddRangeAsync(IList<T> entities)
            => await Table.AddRangeAsync(entities);

        public async Task<T> UpdateAsync(T entity)
        {
            entity.LastModifiedDate = DateTime.Now;
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
        public async Task SoftDeleteAsync(T entity)
        {
            if (entity is not null)
            {
                entity.IsDeleted = true;
                entity.DeletedDate = DateTime.Now;
                await Task.Run(() => Table.Update(entity));
            }
        }

        public async Task SoftDeleteByIdAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.DeletedDate = DateTime.Now;
                await Task.Run(() => Table.Update(entity));
            }
        }
        public async Task SoftDeleteRangeAsync(IList<T> entities)
        {
            if (entities.Any())
            {
                foreach (var entity in entities)
                {
                    entity.IsDeleted = true;
                    entity.DeletedDate = DateTime.Now;
                }

                await Task.Run(() => Table.UpdateRange(entities));
            }
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task HardDeleteByIdAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            if (entity != null)
            {
                Table.Remove(entity);
                await _appDbContext.SaveChangesAsync();
            }
        }
        public async Task HardDeleteRangeAsync(IList<T> entities)
        {
            await Task.Run(() => Table.RemoveRange(entities));
        }




    }
}
