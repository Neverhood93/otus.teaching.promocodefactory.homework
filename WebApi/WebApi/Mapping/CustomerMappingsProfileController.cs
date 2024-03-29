using AutoMapper;
using Services.Contracts.Customer;
using WebApi.Models.Customer;

namespace WebApi.Mapping
{
    public class CustomerMappingsProfileController : Profile
    {
        public CustomerMappingsProfileController()
        {
            CreateMap<CustomerDTO, CustomerModel>();
            CreateMap<CreatingCustomerModel, CreatingCustomerDTO>();
            CreateMap<UpdatingCustomerModel, UpdatingCustomerDTO>();
        }
    }
}