﻿using Services.Contracts.CustomerPreference;
using Services.Contracts.PromoCode;

namespace Services.Contracts.Customer
{
    public class CreatingCustomerDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual List<PromoCodeDTO> PromoCodes { get; set; }

        public virtual List<CustomerPreferenceDTO> CustomerPreferences { get; set; }
    }
}
