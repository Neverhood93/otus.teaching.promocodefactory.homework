using Services.Contracts.Role;

namespace Services.Abstractions
{
    public interface IRoleService
    {
        Task<RoleDTO> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(CreatingRoleDTO creatingRoleDTO);

        //Task UpdateAsync(Guid id, UpdatingRoleDTO updatingRoleDTO);

        //Task DeleteAsync(Guid id);
    }
}
