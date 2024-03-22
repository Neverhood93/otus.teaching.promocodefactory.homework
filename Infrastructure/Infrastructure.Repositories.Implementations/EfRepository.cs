using Services.Repositories.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Repositories.Implementations
{
    public class EfRepository<T> : IRepository<T> 
        where T : BaseEntity
    {
        protected readonly DbContext Context;

        private readonly DbSet<T> _entity;

        public EfRepository(DbContext context)
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
            Guid newId = Guid.NewGuid();
            entity.Id = newId;

            List<T> listData = _entity as List<T>;
            if (listData == null)
            {
                Task.FromException(new ArgumentNullException("listData is null"));
            }

            listData.Add(entity);

            return Task.FromResult(entity);
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
