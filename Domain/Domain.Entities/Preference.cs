
namespace Domain.Entities
{
    public class Preference : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<PromoCode> PromoCodes { get; set; }

        public virtual List<CustomerPreference> CustomerPreferences { get; set; }
    }
}