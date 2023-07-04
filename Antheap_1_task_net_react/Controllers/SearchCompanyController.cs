using Antheap_1_task_net_react.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Antheap_1_task_net_react.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchCompanyController : ControllerBase
    {
        private readonly ICompanyOperation _companyOperation;

        public SearchCompanyController(ICompanyOperation companyOperation)
        {
            _companyOperation = companyOperation;
        }

        [HttpGet("company/{nip}")]
        public async Task<IActionResult> GetCompany(string nip)
        {
            var company = await _companyOperation.GetCompanyByNip(nip);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpGet("company")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _companyOperation.GetAll();
            return Ok(companies);
        }
    }
}
