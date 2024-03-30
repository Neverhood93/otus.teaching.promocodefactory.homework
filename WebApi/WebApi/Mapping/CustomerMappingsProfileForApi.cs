using AutoMapper;
using Services.Contracts.Customer;
using WebApi.Models.Customer;

namespace WebApi.Mapping
{
    public class CustomerMappingsProfileForApi : Profile
    {
        public CustomerMappingsProfileForApi()
        {
            CreateMap<CustomerDTO, CustomerModel>();
            CreateMap<CreatingCustomerModel, CreatingCustomerDTO>();
            CreateMap<UpdatingCustomerModel, UpdatingCustomerDTO>();
        }
    }
}