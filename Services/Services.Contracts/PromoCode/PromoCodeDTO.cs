using Services.Contracts.Customer;
using Services.Contracts.Preference;

namespace Services.Contracts.PromoCode
{
    public class PromoCodeDTO
    {
        public string Code { get; set; }


        public Guid CustomerId { get; set; }

        public virtual CustomerDTO Customer { get; set; }


        public Guid PreferenceId { get; set; }

        public virtual PreferenceDTO Preference { get; set; }
    }
}
