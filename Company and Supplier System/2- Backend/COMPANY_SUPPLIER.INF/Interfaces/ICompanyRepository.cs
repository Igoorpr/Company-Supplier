using COMPANY_SUPPLIER.INF.Entities;

namespace COMPANY_SUPPLIER.INF.Interfaces
{
    public interface ICompanyRepository
    {
        Task SaveCompany(COMPANY company);
        Task<COMPANY> FindCompany(string CompanyCnpj);
        Task UpdateCompany(COMPANY company);
        Task DeleteCompany(string CompanyCnpj);
    }
}
