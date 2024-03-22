using Domain.Entities;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations
{
    public class InMemoryRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        protected IEnumerable<T> Data { get; set; }

        public InMemoryRepository(IEnumerable<T> data)
        {
            Data = data;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(Data);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public Task<T> CreateAsync(T entity)
        {
            Guid newId = Guid.NewGuid();
            entity.Id = newId;

            List<T> listData = Data as List<T>;
            if (listData == null)
            {
                Task.FromException(new ArgumentNullException("listData is null"));
            }

            listData.Add(entity);

            return Task.FromResult(entity);
        }

        public Task UpdateAsync(T oldEntity, T newEntity)
        {
            List<T> listData = Data as List<T>;
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
            List<T> listData = Data as List<T>;
            if (listData == null)
            {
                Task.FromException(new ArgumentNullException("listData is null"));
            }

            listData.Remove(entity);

            return Task.CompletedTask;
        }
    }
}