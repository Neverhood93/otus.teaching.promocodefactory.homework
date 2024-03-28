using AutoMapper;
using Domain.Entities;
using Services.Contracts.Role;

namespace Services.Implementations.Mapping
{
    public class RoleMappingsProfile : Profile
    {
        public RoleMappingsProfile()
        {
            CreateMap<Role, RoleDTO>();

            CreateMap<CreatingRoleDTO, Role>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Employees, map => map.Ignore());

            CreateMap<UpdatingRoleDTO, Role>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.Employees, map => map.Ignore());
        }
    }
}