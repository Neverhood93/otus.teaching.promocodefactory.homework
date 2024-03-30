using Services.Contracts.Employee;

namespace Services.Contracts.Role
{
    public class RoleDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<EmployeeDTO> Employees { get; set; }
    }
}