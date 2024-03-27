using Services.Repositories.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Infrastructure.EntityFramework;

namespace Infrastructure.Repositories.Implementations
{
    public class EfRepository<T> : IRepository<T> 
        where T : BaseEntity
    {
        protected readonly DatabaseContext Context;

        private readonly DbSet<T> _entity;

        public EfRepository(DatabaseContext context)
        {
            Context = context;
            _entity = Context.Set<T>();
        }


        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_entity as IEnumerable<T>);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_entity.FirstOrDefault(x => x.Id == id));
        }

        public Task<T> CreateAsync(T entity)
        {
            var newEntity = _entity.Add(entity);
            Context.SaveChangesAsync();
            return Task.FromResult(newEntity.Entity);
        }

        public Task UpdateAsync(T oldEntity, T newEntity)
        {
            List<T> listData = _entity as List<T>;
            if (listData == null)
            {
                Task.FromException(new ArgumentNullException("listData is null"));
            }

            newEntity.Id = oldEntity.Id;

            listData.Remove(oldEntity);
            listData.Add(newEntity);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            List<T> listData = _entity as List<T>;
            if (listData == null)
            {
                Task.FromException(new ArgumentNullException("listData is null"));
            }

            listData.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
