using COMPANY_SUPPLIER.APP.DTO.Supplier;
using COMPANY_SUPPLIER.DOM.Interfaces;

namespace COMPANY_SUPPLIER.APP.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public class SupplierAppService : ISupplierAppService
    {
        private readonly ISupplierService _supplierservice;

        public SupplierAppService(ISupplierService supplierservice)
        {
            (_supplierservice) = (supplierservice);
        }

        public async Task SaveSupplier(SupplierDTO supplierdto)
        {
            await _supplierservice.SaveSupplier(supplierdto.CreateModel());
        }

        public async Task<object> FindSupplier(SupplierKeyDTO supplierkeydto)
        {
            return await _supplierservice.FindSupplier(supplierkeydto.CreateModel());
        }

        public async Task UpdateSupplier(SupplierDTO supplierdto)
        {
            await _supplierservice.UpdateSupplier(supplierdto.CreateModel());
        }

        public async Task DeleteSupplier(SupplierKeyDTO supplierkeydto)
        {
            await _supplierservice.DeleteSupplier(supplierkeydto.CreateModel());
        }
    }
}
