
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;
using Services.Repositories.Abstractions;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController
        : ControllerBase
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly EmployeeHelper _employeeHelper;

        public EmployeesController(IRepository<Employee> employeeRepository, EmployeeHelper employeeHelper)
        {
            _employeeRepository = employeeRepository;
            _employeeHelper = employeeHelper;
        }

        /// <summary>
        /// Получить данные всех сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<EmployeeShortResponse>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var employeesModelList = employees.Select(x =>
                new EmployeeShortResponse()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FullName = x.FullName,
                }).ToList();

            return employeesModelList;
        }

        /// <summary>
        /// Получить данные сотрудника по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmployeeResponse>> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            var employeeModel = new EmployeeResponse()
            {
                Id = employee.Id,
                Email = employee.Email,
                Roles = employee.Roles?.Select(x => new RoleItemResponse()
                {
                    Name = x.Name,
                    Description = x.Description
                }).ToList(),
                FullName = employee.FullName,
                AppliedPromocodesCount = employee.AppliedPromocodesCount
            };

            return employeeModel;
        }

        /// <summary>
        /// Создать нового сотрудника по модели из запроса
        /// </summary>
        /// <param name="model">Модель из запроса</param>
        /// <returns>Нового сотрудника</returns>
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployeeAsync(InputEmployeeModel model)
        {
            Employee employee = _employeeHelper.GetEmployeeFromInputModel(model);

            try
            {
                return await _employeeRepository.CreateAsync(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Изменить существующего сотрудника
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <param name="model">Модель из запроса</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployeeAsync(Guid id, InputEmployeeModel model)
        {
            Employee oldEmployee = await _employeeRepository.GetByIdAsync(id);
            if (oldEmployee == null)
            {
                return BadRequest();
            }

            Employee newEmployee = _employeeHelper.GetEmployeeFromInputModel(model);

            try
            {
                await _employeeRepository.UpdateAsync(oldEmployee, newEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok();
        }

        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployeeAsync(Guid id)
        {
            Employee employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return BadRequest();
            }

            try
            {
                await _employeeRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok();
        }
    }
}