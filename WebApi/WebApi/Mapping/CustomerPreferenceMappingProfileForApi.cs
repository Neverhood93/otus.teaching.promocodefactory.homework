using AutoMapper;
using Services.Contracts.CustomerPreference;
using WebApi.Models.CustomerPreference;

namespace WebApi.Mapping
{
    public class CustomerPreferenceMappingsProfileForApi : Profile
    {
        public CustomerPreferenceMappingsProfileForApi()
        {
            CreateMap<CustomerPreferenceDTO, CustomerPreferenceModel>();
        }
    }
}