
namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int AppliedPromocodesCount { get; set; }

        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }             
    }
}