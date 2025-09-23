using COMPANY_SUPPLIER.DOM.Models;

namespace COMPANY_SUPPLIER.DOM.Interfaces
{
    public interface ICompanyService
    {
        Task SaveCompany(CompanyModel company);
        Task<CompanyModel> FindCompany(CompanyModel company);
        Task UpdateCompany(CompanyModel company);
        Task DeleteCompany(CompanyModel company);
    }
}
