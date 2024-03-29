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
                //.ForMember(d => d.PromoCodes, map => map.Ignore())
                //.ForMember(d => d.CustomerPreferences, map => map.Ignore());
        }
    }
}