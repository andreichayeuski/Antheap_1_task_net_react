using Antheap_1_task_net_react.ViewModels;
namespace Antheap_1_task_net_react.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyViewModel>> GetAllCompanies();
        Task<CompanyViewModel> GetCompanyById(int id);
        Task<CompanyViewModel> GetCompanyByNip(string nip);
        Task<CompanyViewModel> CreateCompany(CompanyViewModel companyViewModel);
        Task<CompanyViewModel> UpdateCompany(int id, CompanyViewModel companyViewModel);
        Task<bool> DeleteCompany(int id);
    }
}
