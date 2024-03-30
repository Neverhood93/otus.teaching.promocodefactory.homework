using AutoMapper;
using Services.Contracts.CustomerPreference;
using WebApi.Models.CustomerPreference;

namespace WebApi.Mapping
{
    public class CustomerPreferenceMappingsProfileController : Profile
    {
        public CustomerPreferenceMappingsProfileController()
        {
            CreateMap<CustomerPreferenceDTO, CustomerPreferenceModel>();
                //.ForMember(d => d.CustomerName, map => map.MapFrom(m => m.Customer.LastName));
        }
    }
}