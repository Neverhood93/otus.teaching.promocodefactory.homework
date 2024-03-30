using AutoMapper;
using Services.Contracts.Role;
using WebApi.Models.Role;

namespace WebApi.Mapping
{
    public class RoleMappingsProfileForApi : Profile
    {
        public RoleMappingsProfileForApi()
        {
            CreateMap<RoleDTO, RoleModel>();
        }
    }
}