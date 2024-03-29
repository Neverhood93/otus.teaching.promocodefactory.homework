using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations
{
    public class PreferenceRepository : EfRepository<Preference>, IPreferenceRepository
    {
        public PreferenceRepository(DatabaseContext context) : base(context)
        {
        }

        //public override async Task<List<Preference>> GetAllAsync()
        //{
        //    return await Context.Set<Preference>()
        //        .Include(p => p.CustomerPreferences)
        //        .ThenInclude(cp => cp.Customer)
        //        .ToListAsync();
        //}
    }
}