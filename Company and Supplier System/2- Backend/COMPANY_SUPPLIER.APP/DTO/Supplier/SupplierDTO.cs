using COMPANY_SUPPLIER.DOM.Models;

namespace COMPANY_SUPPLIER.APP.DTO.Supplier
{
    public class SupplierDTO
    {
        /// <summary>
        /// Represents the unique CPF or CNPJ identifier of the supplier.
        /// </summary>
        public string SupplierCpfCnpj { get; set; }

        /// <summary>
        /// Represents the full name of the supplier.
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Represents the type of supplier: 'F' for individual (Pessoa Física) or 'J' for company (Pessoa Jurídica).
        /// </summary>
        public string SupplierType { get; set; }

        /// <summary>
        /// Represents the supplier's email address (optional).
        /// </summary>
        public string? SupplierEmail { get; set; }

        /// <summary>
        /// Represents the postal code (ZIP code) of the supplier's address.
        /// </summary>
        public string SupplierPostalCode { get; set; }

        /// <summary>
        /// Represents the supplier's RG (General Registry) identification number (optional).
        /// </summary>
        public string? SupplierRG { get; set; }

        /// <summary>
        /// Represents the birth date of the supplier (optional).
        /// </summary>
        public DateTime? SupplierBirthDate { get; set; }

        protected internal SupplierModel CreateModel()
        {
            return new SupplierModel(
                SupplierCpfCnpj,
                SupplierName,
                SupplierType,
                SupplierEmail,
                SupplierPostalCode,
                SupplierRG,
                SupplierBirthDate);
        }
    }
}
