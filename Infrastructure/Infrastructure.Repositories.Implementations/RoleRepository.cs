using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations
{
    public class RoleRepository : EfRepository<Role>, IRoleRepository
    {
        public RoleRepository(DatabaseContext context) : base(context)
        {            
        }

        public override async Task<List<Role>> GetAllAsync()
        {
            return await Context.Set<Role>().Include(r => r.Employees).ToListAsync();
        }
    }
}
