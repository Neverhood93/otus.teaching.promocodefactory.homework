using Services.Contracts.Role;

namespace Services.Abstractions
{
    public interface IRoleService
    {
        Task<List<RoleDTO>> GetAllAsync();
    }
}
