using COMPANY_SUPPLIER.APP.DTO;

namespace COMPANY_SUPPLIER.APP.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICompanySupplierAppService
    {
        /// <summary>
        /// 
        /// </summary>
        Task SaveCompanySupplier(CompanySupplierDTO supplierdto);
        /// <summary>
        /// 
        /// </summary>
        Task<IEnumerable<object>> FindCompanySupplier(CompanySupplierDTO supplierkeydto);
        /// <summary>
        /// 
        /// </summary>
        Task DeleteCompanySupplier(CompanySupplierDTO supplierdto);
    }
}
