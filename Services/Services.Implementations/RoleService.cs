using AutoMapper;
using Domain.Entities;
using Services.Abstractions;
using Services.Contracts.Role;
using Services.Repositories.Abstractions;

namespace Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<RoleDTO> GetByIdAsync(Guid id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            return _mapper.Map<Role, RoleDTO>(role);
        }

        public async Task<Guid> CreateAsync(CreatingRoleDTO creatingRoleDTO)
        {
            var role = _mapper.Map<CreatingRoleDTO, Role>(creatingRoleDTO);
            var createdRole = await _roleRepository.CreateAsync(role);
            await _roleRepository.SaveChangesAsync();

            return createdRole.Id;
        }

        
    }
}
