
using AutoMapper;
using Services.Contracts.Role;
using WebApi.Models.Role;

namespace WebApi.Mapping
{
    public class RoleMappingsProfileController : Profile
    {
        public RoleMappingsProfileController()
        {
            CreateMap<RoleDTO, RoleModel>();
        }
    }
}
