using WebApi.Models.CustomerPreference;

namespace WebApi.Models.Customer
{
    public class CustomerModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        //public virtual List<PromoCodeDTO> PromoCodes { get; set; }

        public virtual List<CustomerPreferenceModel> CustomerPreferences { get; set; }
    }
}