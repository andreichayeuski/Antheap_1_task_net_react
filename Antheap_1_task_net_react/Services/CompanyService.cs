using Antheap_1_task_net_react.Contracts;
using Antheap_1_task_net_react.Data.Entities;
using Antheap_1_task_net_react.Data.Repositories;
using Antheap_1_task_net_react.Settings;
using Antheap_1_task_net_react.ViewModels;
using AutoMapper;

namespace Antheap_1_task_net_react.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper, IConfiguration configuration)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<CompanyViewModel>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompanyViewModel>>(companies);
        }

        public async Task<CompanyViewModel> GetCompanyById(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            return _mapper.Map<CompanyViewModel>(company);
        }

        public async Task<CompanyViewModel> GetCompanyByNip(string nip)
        {
            var company = await _companyRepository.GetCompanyByNipAsync(nip);
            if (company == null)
            {
                company = await SearchCompanyInAPI(nip);
                if (company == null)
                {
                    return null;
                }
            }
            var companyViewModel = _mapper.Map<CompanyViewModel>(company);
            companyViewModel = MapRepresentatives(companyViewModel, company);
            return companyViewModel;
        }

        public async Task<CompanyViewModel> CreateCompany(CompanyViewModel companyViewModel)
        {
            var company = _mapper.Map<CompanyEntity>(companyViewModel);
            await _companyRepository.AddAsync(company);
            return _mapper.Map<CompanyViewModel>(company);
        }

        public async Task<CompanyViewModel> UpdateCompany(int id, CompanyViewModel companyViewModel)
        {
            var existingCompany = await _companyRepository.GetByIdAsync(id);
            if (existingCompany == null)
            {
                throw new Exception("Company not found");
            }

            _mapper.Map(companyViewModel, existingCompany);
            await _companyRepository.UpdateAsync(existingCompany);
            return _mapper.Map<CompanyViewModel>(existingCompany);
        }

        public async Task<bool> DeleteCompany(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return false;
            }

            await _companyRepository.DeleteAsync(company);
            return true;
        }

        private async Task<CompanyEntity> SearchCompanyInAPI(string nip)
        {
            try
            {
                var settings = _configuration.GetSection("APIRejestrWL").Get<APIRejestrWLSettings>();
                string url = $"{settings.BaseUrl}{settings.SearchByNipUrl}{nip}?date={DateTime.Now:yyyy-MM-dd}";

                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadFromJsonAsync<SearchNipContract>();
                    var company = result.Result.Subject;
                    await _companyRepository.AddAsync(company);
                    return company;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        private CompanyViewModel MapRepresentatives(CompanyViewModel companyViewModel, CompanyEntity companyEntity)
        {
            companyViewModel.Representatives = companyEntity.Representatives.Select(representative => { return _mapper.Map<PersonViewModel>(representative.Person); }).ToList();
            return companyViewModel;
        }
    }
}
