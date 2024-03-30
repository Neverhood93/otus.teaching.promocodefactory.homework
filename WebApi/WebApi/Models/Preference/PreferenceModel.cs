using WebApi.Models.Customer;
using WebApi.Models.CustomerPreference;

namespace WebApi.Models.Preference
{
    public class PreferenceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual List<CustomerPreferenceModel> CustomerPreferences { get; set; }
    }
}