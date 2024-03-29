using AutoMapper;
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

        public async Task<List<RoleDTO>> GetAllAsync()
        {
            return _mapper.Map<List<RoleDTO>>(await _roleRepository.GetAllAsync());
        }
    }
}