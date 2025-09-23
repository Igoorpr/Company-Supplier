using COMPANY_SUPPLIER.DOM.Models;

namespace COMPANY_SUPPLIER.DOM.Interfaces
{
    public interface ISupplierService
    {
        Task SaveSupplier(SupplierModel supplier);
        Task<SupplierModel> FindSupplier(SupplierModel supplier);
        Task UpdateSupplier(SupplierModel supplier);
        Task DeleteSupplier(SupplierModel supplier);
    }
}
