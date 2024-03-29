using WebApi.Models.Customer;
using WebApi.Models.Preference;

namespace WebApi.Models.CustomerPreference
{
    public class CustomerPreferenceModel
    {
        public Guid CustomerId { get; set; }

        public virtual CustomerModel Customer { get; set; }


        public Guid PreferenceId { get; set; }

        public virtual PrefernceModel Preference { get; set; }
    }
}
