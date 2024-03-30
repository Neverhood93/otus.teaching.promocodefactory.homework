using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using WebApi.Models.Role;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Роли сотрудников
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;
        private readonly IMapper _mapper;

        public RoleController(IRoleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить данные всех ролей c вложенными сотрудниками
        /// </summary>
        /// <returns>Список ролей c вложенными сотрудниками</returns>
        [HttpGet]
        public async Task<List<RoleModel>> GetAllEntitiesAsync()
        {
            return _mapper.Map<List<RoleModel>>(await _service.GetAllAsync());
        }
    }
}