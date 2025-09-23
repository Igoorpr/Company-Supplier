using COMPANY_SUPPLIER.INF.Entities.Procedures;

namespace COMPANY_SUPPLIER.INF.Interfaces
{
    public interface ICompanySupplierRepository
    {
        Task SaveCompanySupplier(string CompanyCnpj, string SupplierCpfCnpj);
        Task<IEnumerable<SP_COMPANY_SUPPLIER_SELECT>> FindCompanySupplier(string? CpfCnpj, string? Name);
        Task DeleteCompanySupplier(string CpfCnpj);
    }
}
