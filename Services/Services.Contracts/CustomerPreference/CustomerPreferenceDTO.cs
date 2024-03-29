
using Services.Contracts.Customer;
using Services.Contracts.Preference;

namespace Services.Contracts.CustomerPreference
{
    public class CustomerPreferenceDTO
    {
        public Guid CustomerId { get; set; }

        public virtual CustomerDTO Customer { get; set; }


        public Guid PreferenceId { get; set; }

        public virtual PreferenceDTO Preference { get; set; }
    }
}
