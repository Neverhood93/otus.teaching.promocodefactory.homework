using AutoMapper;
using Domain.Entities;
using Services.Contracts.Employee;

namespace Services.Implementations.Mapping
{
    public class EmployeeMappingsProfile : Profile
    {
        public EmployeeMappingsProfile()
        {
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<CreatingEmployeeDTO, Employee>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Role, map => map.Ignore());

            CreateMap<UpdatingEmployeeDTO, Employee>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Role, map => map.Ignore());
        }
    }
}