using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using WebApi.Models.Preference;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Предпочтения клиентов
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PreferenceController : ControllerBase
    {
        private readonly IPreferenceService _service;
        private readonly IMapper _mapper;

        public PreferenceController(IPreferenceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить данные всех ролей c вложенными клиентами
        /// </summary>
        /// <returns>Список ролей c вложенными клиентами</returns>
        [HttpGet]
        public async Task<List<PreferenceModel>> GetAllEntitiesAsync()
        {
            return _mapper.Map<List<PreferenceModel>>(await _service.GetAllAsync());
        }
    }
}