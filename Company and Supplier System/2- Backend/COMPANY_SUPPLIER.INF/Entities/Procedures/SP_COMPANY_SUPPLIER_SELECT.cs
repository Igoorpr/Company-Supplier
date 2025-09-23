namespace COMPANY_SUPPLIER.INF.Entities.Procedures
{
    public record class SP_COMPANY_SUPPLIER_SELECT
    {
        public string Company_Cnpj { get; set; }   
	    public string Company_Name { get; set; } 
        public string Company_State { get; set; }
        public string Supplier_Cpf_Cnpj { get; set; }
        public string Supplier_Name { get; set; }
        public string Supplier_Type { get; set; }
        public string? Supplier_Email { get; set; }
        public string Supplier_PostalCode { get; set; }
        public string? Supplier_RG { get; set; }
        public DateTime? Supplier_BirthDate { get; set; }
    }
}
