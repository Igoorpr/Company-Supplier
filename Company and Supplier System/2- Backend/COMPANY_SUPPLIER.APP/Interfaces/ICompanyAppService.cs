using COMPANY_SUPPLIER.APP.DTO.Company;

namespace COMPANY_SUPPLIER.APP.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICompanyAppService
    {
        /// <summary>
        /// 
        /// </summary>
        Task SaveCompany(CompanyDTO companydto);
        /// <summary>
        /// 
        /// </summary>
        Task<object> FindCompany(CompanyKeyDTO companykeydto);
        /// <summary>
        /// 
        /// </summary>
        Task UpdateCompany(CompanyDTO companydto);
        /// <summary>
        /// 
        /// </summary>
        Task DeleteCompany(CompanyKeyDTO companykeydto);
    }
}
