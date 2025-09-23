using COMPANY_SUPPLIER.DOM.Models;

namespace COMPANY_SUPPLIER.APP.DTO.Company
{
    public class CompanyKeyDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public string CompanyCnpj { get; set; }

        protected internal CompanyModel CreateModel()
        {
            return new CompanyModel(CompanyCnpj);
        }
    }
}
