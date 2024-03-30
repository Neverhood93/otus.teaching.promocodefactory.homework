using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts.Customer;
using WebApi.Models.Customer;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Клиенты
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить данные всех клиентов с их предпочтениями
        /// </summary>
        /// <returns>Список клиентов с их предпочтениями</returns>
        [HttpGet]
        public async Task<List<CustomerModel>> GetAllEntitiesAsync()
        {
            return _mapper.Map<List<CustomerModel>>(await _service.GetAllAsync());
        }

        /// <summary>
        /// Получить данные клиента по Id с его предпочтениями
        /// </summary>
        /// <returns>Данные клиента с его предпочтениями</returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEntityByIdAsync(Guid id)
        {
            var entity = _mapper.Map<CustomerModel>(await _service.GetByIdAsync(id));
            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(entity);
        }

        /// <summary>
        /// Создать нового клиента по модели из запроса
        /// </summary>
        /// <param name="model">Модель из запроса</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateEntityAsync(CreatingCustomerModel model)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingCustomerDTO>(model)));
        }

        /// <summary>
        /// Изменить существующего клиента
        /// </summary>
        /// <param name="id">Id клиента</param>
        /// <param name="model">Модель из запроса</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEntityAsync(Guid id, UpdatingCustomerModel model)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingCustomerModel, UpdatingCustomerDTO>(model));

            return Ok();
        }

        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="id">Id клиента</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEntityAsync(Guid id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}