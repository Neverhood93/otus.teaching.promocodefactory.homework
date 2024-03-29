using Services.Contracts.CustomerPreference;
using Services.Contracts.PromoCode;

namespace Services.Contracts.Customer
{
    public class UpdatingCustomerDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
