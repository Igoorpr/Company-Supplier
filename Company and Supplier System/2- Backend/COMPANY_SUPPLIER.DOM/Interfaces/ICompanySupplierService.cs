using COMPANY_SUPPLIER.DOM.Models;

namespace COMPANY_SUPPLIER.DOM.Interfaces
{
    public interface ICompanySupplierService
    {
        Task SaveCompanySupplier(CompanySupplierModel companysupplier);
        Task<IEnumerable<CompanySupplierModel>> FindCompanySupplier(CompanySupplierModel companysupplier);
        Task DeleteCompanySupplier(CompanySupplierModel companysupplier);
    }
}
