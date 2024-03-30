
namespace WebApi.Models.Employee
{
    public class CreatingEmployeeModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int AppliedPromocodesCount { get; set; }

        public Guid RoleId { get; set; }
    }
}
