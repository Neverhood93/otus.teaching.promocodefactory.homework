using AutoMapper;
using Domain.Entities;
using Services.Contracts.CustomerPreference;

namespace Services.Implementations.Mapping
{
    public class CustomerPreferenceMappingsProfile : Profile
    {
        public CustomerPreferenceMappingsProfile()
        {
            CreateMap<CustomerPreference, CustomerPreferenceDTO>()
                .ForMember(d => d.CustomerName, map => map.MapFrom(m => m.Customer.LastName))
                .ForMember(d => d.PreferenceName, map => map.MapFrom(m => m.Preference.Name));
        }
    }
}
