using AutoMapper;
using Services.Abstractions;
using Services.Contracts.Preference;
using Services.Repositories.Abstractions;

namespace Services.Implementations
{
    public class PreferenceService : IPreferenceService
    {
        private readonly IMapper _mapper;
        private readonly IPreferenceRepository _preferenceRepository;

        public PreferenceService(IMapper mapper, IPreferenceRepository preferenceRepository)
        {
            _mapper = mapper;
            _preferenceRepository = preferenceRepository;
        }

        public async Task<List<PreferenceDTO>> GetAllAsync()
        {
            return _mapper.Map<List<PreferenceDTO>>(await _preferenceRepository.GetAllAsync());
        }
    }
}