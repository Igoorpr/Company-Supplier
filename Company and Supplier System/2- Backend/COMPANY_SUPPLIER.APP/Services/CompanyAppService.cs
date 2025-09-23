using COMPANY_SUPPLIER.APP.DTO.Company;
using COMPANY_SUPPLIER.APP.Interfaces;
using COMPANY_SUPPLIER.DOM.Interfaces;

namespace COMPANY_SUPPLIER.APP.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class CompanyAppService : ICompanyAppService
    {
        private readonly ICompanyService _companyservice;

        public CompanyAppService(ICompanyService companyservice)
        {
            (_companyservice) = (companyservice);
        }

        public async Task SaveCompany(CompanyDTO companydto)
        {
            await _companyservice.SaveCompany(companydto.CreateModel());
        }

        public async Task<object> FindCompany(CompanyKeyDTO companykeydto)
        {
            return await _companyservice.FindCompany(companykeydto.CreateModel());
        }

        public async Task UpdateCompany(CompanyDTO companydto)
        {
            await _companyservice.UpdateCompany(companydto.CreateModel());
        }

        public async Task DeleteCompany(CompanyKeyDTO companykeydto)
        {
            await _companyservice.DeleteCompany(companykeydto.CreateModel());
        }
    }
}
