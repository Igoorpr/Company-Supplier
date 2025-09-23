using COMPANY_SUPPLIER.DOM.ValueObjects;

namespace COMPANY_SUPPLIER.DOM.Models
{
    public record class SupplierModel
    {
        public CpfCnpj SupplierCpfCnpj { get; set; }
        public string SupplierName { get; set; }
        public CustomerType SupplierType { get; set; }
        public string? SupplierEmail { get; set; }
        public string SupplierPostalCode { get; set; }
        public string? SupplierRG { get; set; }
        public DateTime? SupplierBirthDate { get; set; }

        public SupplierModel(CpfCnpj suppliercpfcnpj, string suppliername, CustomerType suppliertype, string? supplieremail, string supplierpostalcode, string? supplierrg, DateTime? supplierbirthdate)
        {
            (SupplierCpfCnpj, SupplierName, SupplierType, SupplierEmail, SupplierPostalCode, SupplierRG, SupplierBirthDate) =
            (suppliercpfcnpj, suppliername, suppliertype, supplieremail, supplierpostalcode, supplierrg, supplierbirthdate);
        }
        public SupplierModel(CpfCnpj suppliercpfcnpj)
        {
            (SupplierCpfCnpj) =
            (suppliercpfcnpj);
        }

    }
}
