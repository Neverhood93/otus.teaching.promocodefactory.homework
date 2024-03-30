
namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual List<PromoCode> PromoCodes { get; set; }

        public virtual List<CustomerPreference> CustomerPreferences { get; set; }
    }
}