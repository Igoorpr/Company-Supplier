using COMPANY_SUPPLIER.DOM.Models;

namespace COMPANY_SUPPLIER.APP.DTO.Supplier
{
    public class SupplierKeyDTO
    {
        /// <summary>
        /// Represents the unique CPF or CNPJ identifier of the supplier.
        /// </summary>
        public string SupplierCpfCnpj { get; set; }

        protected internal SupplierModel CreateModel()
        {
            return new SupplierModel(SupplierCpfCnpj);
        }
    }
}
