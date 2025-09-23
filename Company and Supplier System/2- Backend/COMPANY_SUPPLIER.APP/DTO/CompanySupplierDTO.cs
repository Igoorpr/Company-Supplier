using COMPANY_SUPPLIER.DOM.Models;

namespace COMPANY_SUPPLIER.APP.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class CompanySupplierDTO
    {
        /// <summary>
        /// Represents the unique CNPJ identifier of the company.
        /// </summary>
        public string? Company_Cnpj { get; set; }

        /// <summary>
        /// Represents the unique CPF/CNPJ identifier of the Supplier.
        /// </summary>
        public string? CpfCnpj { get; set; }

        /// <summary>
        /// Represents the official name of the company.
        /// </summary>
        public string? Name { get; set; }

        protected internal CompanySupplierModel CreateModel()
        {
            return new CompanySupplierModel(Company_Cnpj, CpfCnpj, Name);
        }
    }
}
