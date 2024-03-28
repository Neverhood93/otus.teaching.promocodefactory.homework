using Domain.Entities;
using Infrastructure.EntityFramework;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations
{
    public class RoleRepository : EfRepository<Role>, IRoleRepository
    {
        public RoleRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
