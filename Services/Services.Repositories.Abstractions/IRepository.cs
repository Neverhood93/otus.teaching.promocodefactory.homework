using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<T> CreateAsync(T entity);

        Task UpdateAsync(T oldEntity, T newEntity);

        Task DeleteAsync(T entity);
    }
}