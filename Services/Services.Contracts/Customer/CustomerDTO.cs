using Services.Contracts.CustomerPreference;

namespace Services.Contracts.Customer
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        //public virtual List<PromoCodeDTO> PromoCodes { get; set; }

        public virtual List<CustomerPreferenceDTO> CustomerPreferences { get; set; }
    }
}