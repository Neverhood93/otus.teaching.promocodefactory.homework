using AutoMapper;
using Services.Contracts.Preference;
using WebApi.Models.Preference;

namespace WebApi.Mapping
{
    public class PreferenceMappingsProfileController : Profile
    {
        public PreferenceMappingsProfileController()
        {
            CreateMap<PreferenceDTO, PreferenceModel>();
        }
    }
}