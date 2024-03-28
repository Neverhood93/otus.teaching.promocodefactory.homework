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
        }
    }
}