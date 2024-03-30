using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task<List<Customer>> GetAllAsync()
        {
            return await Context.Set<Customer>()
                .Include(r => r.CustomerPreferences)
                .ThenInclude(cp => cp.Preference)
                .ToListAsync();
        }

        public override async Task<Customer> GetByIdAsync(Guid id)
        {
            return await Context.Set<Customer>()
                .Include(r => r.CustomerPreferences)
                .ThenInclude(cp => cp.Preference)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}