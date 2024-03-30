
namespace Services.Contracts.Employee
{
    public class CreatingEmployeeDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int AppliedPromocodesCount { get; set; }

        public Guid RoleId { get; set; }
    }
}