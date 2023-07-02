using Antheap_1_task_net_react.Data.Contexts;
using Antheap_1_task_net_react.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Antheap_1_task_net_react.Data.Repositories
{
    public class CompanyRepository : Repository<CompanyEntity>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CompanyEntity> GetCompanyByNipAsync(string nip)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Nip == nip);
        }
    }
}
