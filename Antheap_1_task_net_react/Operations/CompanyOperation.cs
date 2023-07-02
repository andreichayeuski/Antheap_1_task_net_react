using Antheap_1_task_net_react.Services;
using Antheap_1_task_net_react.ViewModels;

namespace Antheap_1_task_net_react.Operations
{
    public class CompanyOperation : ICompanyOperation
    {
        private readonly ICompanyService _companyService;

        public CompanyOperation(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<List<CompanyViewModel>> GetAll()
        {
            var companies = await _companyService.GetAllCompanies();
            return companies.ToList();
        }

        public async Task<CompanyViewModel> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            return company;
        }

        public async Task<CompanyViewModel> GetCompanyByNip(string nip)
        {
            var company = await _companyService.GetCompanyByNip(nip);
            return company;
        }
    }
}
