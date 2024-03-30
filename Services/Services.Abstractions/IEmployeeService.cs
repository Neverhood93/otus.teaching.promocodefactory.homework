using Services.Contracts.Employee;

namespace Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllAsync();

        Task<EmployeeDTO> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(CreatingEmployeeDTO creatingEmployeeDTO);

        Task UpdateAsync(Guid id, UpdatingEmployeeDTO updatingEmployeeDTO);

        Task DeleteAsync(Guid id);
    }
}