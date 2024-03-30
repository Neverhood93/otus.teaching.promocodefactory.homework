using AutoMapper;
using Domain.Entities;
using Services.Contracts.Preference;

namespace Services.Implementations.Mapping
{
    public class PreferenceMappingsProfile : Profile
    {
        public PreferenceMappingsProfile()
        {
            CreateMap<Preference, PreferenceDTO>();
        }
    }
}