using AutoMapper;
using Services.Contracts.Employee;
using WebApi.Models.Employee;

namespace WebApi.Mapping
{
    public class EmployeeMappingsProfileController : Profile
    {
        public EmployeeMappingsProfileController()
        {
            CreateMap<EmployeeDTO, EmployeeModel>();
            CreateMap<CreatingEmployeeModel, CreatingEmployeeDTO>();
            CreateMap<UpdatingEmployeeModel, UpdatingEmployeeDTO>();
        }
    }
}