namespace COMPANY_SUPPLIER.DOM.Models
{
    public record class CompanySupplierModel
    {
        public string? Company_Cnpj { get; set; }
        public string? CpfCnpj { get; set; }
        public string? Name { get; set; }
        public string? Company_Name { get; set; }
        public string? Company_State { get; set; }
        public string? Supplier_Cpf_Cnpj { get; set; }
        public string? Supplier_Name { get; set; }
        public string? Supplier_Type { get; set; }
        public string? Supplier_Rg { get; set; }
        public string? Supplier_Email { get; set; }
        public string? Supplier_Birthdate { get; set; }

        public CompanySupplierModel(string? company_cnpj, string cpfcnpj, string name)
        {
            (Company_Cnpj, CpfCnpj, Name) =
            (company_cnpj, cpfcnpj, name);
        }

        public CompanySupplierModel(string? companyCnpj, string? companyName, string? companyState,
                           string? supplierCpfCnpj, string? supplierName, string? supplierType,
                           string? supplierRg, string? supplierEmail, string? supplierBirthdate)
        {
            Company_Cnpj = companyCnpj;
            Company_Name = companyName;
            Company_State = companyState;
            Supplier_Cpf_Cnpj = supplierCpfCnpj;
            Supplier_Name = supplierName;
            Supplier_Type = supplierType;
            Supplier_Rg = supplierRg;
            Supplier_Email = supplierEmail;
            Supplier_Birthdate = supplierBirthdate;
        }
    }
}
