using Services.Contracts.Preference;

namespace Services.Abstractions
{
    public interface IPreferenceService
    {
        Task<List<PreferenceDTO>> GetAllAsync();
    }
}