using AutoMapper;
using Services.Contracts.Employee;
using WebApi.Models.Employee;

namespace WebApi.Mapping
{
    public class EmployeeMappingsProfileForApi : Profile
    {
        public EmployeeMappingsProfileForApi()
        {
            CreateMap<EmployeeDTO, EmployeeModel>();
            CreateMap<CreatingEmployeeModel, CreatingEmployeeDTO>();
            CreateMap<UpdatingEmployeeModel, UpdatingEmployeeDTO>();
        }
    }
}