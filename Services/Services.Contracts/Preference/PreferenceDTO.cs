using Services.Contracts.CustomerPreference;

namespace Services.Contracts.Preference
{
    public class PreferenceDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        //public virtual List<PromoCodeDTO> PromoCodes { get; set; }

        public virtual List<CustomerPreferenceDTO> CustomerPreferences { get; set; }
    }
}