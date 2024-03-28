using WebApi.Models.Employee;

namespace WebApi.Models.Role
{
    public class RoleModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<EmployeeModel> Employees { get; set; }
    }
}
