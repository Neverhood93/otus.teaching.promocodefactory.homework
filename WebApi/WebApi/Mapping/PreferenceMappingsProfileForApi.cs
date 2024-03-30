using AutoMapper;
using Services.Contracts.Preference;
using WebApi.Models.Preference;

namespace WebApi.Mapping
{
    public class PreferenceMappingsProfileForApi : Profile
    {
        public PreferenceMappingsProfileForApi()
        {
            CreateMap<PreferenceDTO, PreferenceModel>();
        }
    }
}