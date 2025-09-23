using COMPANY_SUPPLIER.APP.DTO;
using COMPANY_SUPPLIER.APP.Interfaces;
using COMPANY_SUPPLIER.DOM.Interfaces;

namespace COMPANY_SUPPLIER.APP.Services
{
    public class CompanySupplierAppService : ICompanySupplierAppService
    {
        private readonly ICompanySupplierService _companysupplierservice;

        public CompanySupplierAppService(ICompanySupplierService companysupplierservice)
        {
            (_companysupplierservice) = (companysupplierservice);
        }

        public async Task SaveCompanySupplier(CompanySupplierDTO companysupplierdto)
        {
            await _companysupplierservice.SaveCompanySupplier(companysupplierdto.CreateModel());
        }

        public async Task<IEnumerable<object>> FindCompanySupplier(CompanySupplierDTO companysupplierdto)
        {
            var obj_Company = await _companysupplierservice.FindCompanySupplier(companysupplierdto.CreateModel());
            return obj_Company;
        }

        public async Task DeleteCompanySupplier(CompanySupplierDTO companysupplierdto)
        {
            await _companysupplierservice.DeleteCompanySupplier(companysupplierdto.CreateModel());
        }
    }
}
