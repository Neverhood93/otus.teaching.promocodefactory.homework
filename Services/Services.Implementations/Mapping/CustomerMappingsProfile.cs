using AutoMapper;
using Domain.Entities;
using Services.Contracts.Customer;

namespace Services.Implementations.Mapping
{
    public class CustomerMappingsProfile : Profile
    {
        public CustomerMappingsProfile()
        {
            CreateMap<Customer, CustomerDTO>();

            CreateMap<CreatingCustomerDTO, Customer>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.PromoCodes, map => map.Ignore())
                .ForMember(d => d.CustomerPreferences, map => map.Ignore());

            CreateMap<UpdatingCustomerDTO, Customer>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.PromoCodes, map => map.Ignore())
                .ForMember(d => d.CustomerPreferences, map => map.Ignore());
        }
    }
}