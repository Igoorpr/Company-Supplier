using COMPANY_SUPPLIER.INF.Entities;

namespace COMPANY_SUPPLIER.INF.Interfaces
{
    public interface ISupplierRepository
    {
        Task SaveSupplier(SUPPLIER supplier);
        Task<IEnumerable<SUPPLIER>> FindSupplier(string SupplierCpfCnpj);
        Task UpdateSupplier(SUPPLIER supplier);
        Task DeleteSupplier(string SupplierCpfCnpj);
    }
}
