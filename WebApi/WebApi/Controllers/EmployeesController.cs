using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts.Employee;
using WebApi.Models.Employee;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить данные всех сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<EmployeeModel>> GetAllEntitiesAsync()
        {
            return _mapper.Map<List<EmployeeModel>>(await _service.GetAllAsync());
        }

        /// <summary>
        /// Получить данные сотрудника по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEntityByIdAsync(Guid id)
        {
            var entity = _mapper.Map<EmployeeModel>(await _service.GetByIdAsync(id));
            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(entity);
        }

        /// <summary>
        /// Создать нового сотрудника по модели из запроса
        /// </summary>
        /// <param name="model">Модель из запроса</param>
        /// <returns>Нового сотрудника</returns>
        [HttpPost]
        public async Task<IActionResult> CreateEntityAsync(CreatingEmployeeModel model)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingEmployeeDTO>(model)));
        }

        /// <summary>
        /// Изменить существующего сотрудника
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <param name="model">Модель из запроса</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEntityAsync(Guid id, UpdatingEmployeeModel model)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingEmployeeModel, UpdatingEmployeeDTO>(model));

            return Ok();
        }

        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEntityAsync(Guid id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}