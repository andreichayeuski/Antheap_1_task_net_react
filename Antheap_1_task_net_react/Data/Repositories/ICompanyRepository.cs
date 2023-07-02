using Antheap_1_task_net_react.Data.Entities;

namespace Antheap_1_task_net_react.Data.Repositories
{
    public interface ICompanyRepository : IRepository<CompanyEntity>
    {
        Task<CompanyEntity> GetCompanyByNipAsync(string nip);
    }
}
