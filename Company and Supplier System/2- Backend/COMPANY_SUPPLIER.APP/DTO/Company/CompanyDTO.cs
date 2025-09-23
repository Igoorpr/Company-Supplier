using COMPANY_SUPPLIER.DOM.Models;

namespace COMPANY_SUPPLIER.APP.DTO.Company
{
    public class CompanyDTO
    {
        /// <summary>
        /// Represents the unique CNPJ identifier of the company.
        /// </summary>
        public string CompanyCnpj { get; set; }

        /// <summary>
        /// Represents the official name of the company.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Represents the postal code (ZIP code) of the company's address.
        /// </summary>
        public string CompanyPostalCode { get; set; }

        /// <summary>
        /// Represents the two-letter state abbreviation where the company is located.
        /// </summary>
        public string CompanyState { get; set; }

        protected internal CompanyModel CreateModel()
        {
            return new CompanyModel(
                CompanyCnpj,
                CompanyName,
                CompanyPostalCode,
                CompanyState);
        }
    }
}
