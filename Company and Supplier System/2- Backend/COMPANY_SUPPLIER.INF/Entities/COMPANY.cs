namespace COMPANY_SUPPLIER.INF.Entities
{
    public record class COMPANY
    {
        public string Company_Cnpj { get; set; }   
	    public string Company_Name { get; set; } 
        public string Company_PostalCode { get; set; }
        public string Company_State { get; set; }
    }
}
