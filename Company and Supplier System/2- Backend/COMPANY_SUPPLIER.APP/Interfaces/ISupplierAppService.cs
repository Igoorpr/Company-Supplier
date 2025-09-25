using COMPANY_SUPPLIER.APP.DTO.Supplier;

namespace COMPANY_SUPPLIER.APP.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISupplierAppService
    {
        /// <summary>
        /// 
        /// </summary>
        Task SaveSupplier(SupplierDTO supplierdto);
        /// <summary>
        /// 
        /// </summary>
        Task<IEnumerable<object>> FindSupplier(SupplierKeyDTO supplierkeydto);
        /// <summary>
        /// 
        /// </summary>
        Task UpdateSupplier(SupplierDTO supplierdto);
        /// <summary>
        /// 
        /// </summary>
        Task DeleteSupplier(SupplierKeyDTO supplierkeydto);
    }
}
