using AutoMapper;
using Domain.Entities;
using Services.Abstractions;
using Services.Contracts.Customer;
using Services.Repositories.Abstractions;

namespace Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDTO>> GetAllAsync()
        {
            return _mapper.Map<List<CustomerDTO>>(await _customerRepository.GetAllAsync());
        }

        public async Task<CustomerDTO> GetByIdAsync(Guid id)
        {
            return _mapper.Map<Customer, CustomerDTO>(await _customerRepository.GetByIdAsync(id));
        }

        public async Task<Guid> CreateAsync(CreatingCustomerDTO creatingCustomerDTO)
        {
            var customer = _mapper.Map<CreatingCustomerDTO, Customer>(creatingCustomerDTO);
            var createdCustomer = await _customerRepository.CreateAsync(customer);
            await _customerRepository.SaveChangesAsync();

            return createdCustomer.Id;
        }

        public async Task UpdateAsync(Guid id, UpdatingCustomerDTO updatingCustomerDTO)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new Exception($"Сущность с id = {id} не найдена");
            }

            _mapper.Map(updatingCustomerDTO, customer);
            await _customerRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new Exception($"Сущность с id = {id} не найдена");
            }

            await _customerRepository.DeleteAsync(customer);
        }
    }
}
