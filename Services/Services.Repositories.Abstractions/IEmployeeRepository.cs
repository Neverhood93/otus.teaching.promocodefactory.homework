using Domain.Entities;
using Services.Contracts.Employee;

namespace Services.Repositories.Abstractions
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
