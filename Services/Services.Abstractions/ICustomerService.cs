using Services.Contracts.Customer;

namespace Services.Abstractions
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAllAsync();

        Task<CustomerDTO> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(CreatingCustomerDTO creatingCustomerDTO);

        Task UpdateAsync(Guid id, UpdatingCustomerDTO updatingCustomerDTO);

        Task DeleteAsync(Guid id);
    }
}
