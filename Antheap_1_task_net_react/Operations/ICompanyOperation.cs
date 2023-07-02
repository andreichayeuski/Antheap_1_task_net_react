using Antheap_1_task_net_react.ViewModels;

namespace Antheap_1_task_net_react.Operations
{
    public interface ICompanyOperation : IOperation<CompanyViewModel>
    {
        Task<CompanyViewModel> GetCompanyById(int id);
        Task<CompanyViewModel> GetCompanyByNip(string nip);
    }
}
