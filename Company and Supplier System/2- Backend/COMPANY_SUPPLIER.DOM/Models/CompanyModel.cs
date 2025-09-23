using COMPANY_SUPPLIER.DOM.ValueObjects;

namespace COMPANY_SUPPLIER.DOM.Models
{
    public record class CompanyModel
    {
        public CpfCnpj CompanyCnpj { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPostalCode { get; set; }
        public StateCode CompanyState { get; set; }

        public CompanyModel(CpfCnpj companycnpj, string companyname, string companypostalcode, StateCode companystate)
        {
            (CompanyCnpj, CompanyName, CompanyPostalCode, CompanyState) =
            (companycnpj, companyname, companypostalcode, companystate);
        }
        public CompanyModel(CpfCnpj companycnpj)
        {
            (CompanyCnpj) =
            (companycnpj);
        }
    }
}
