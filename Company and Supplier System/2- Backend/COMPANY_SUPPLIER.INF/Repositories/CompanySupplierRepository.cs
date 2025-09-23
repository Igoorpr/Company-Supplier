using Microsoft.Extensions.Configuration;
using COMPANY_SUPPLIER.INF.Entities.Procedures;
using COMPANY_SUPPLIER.INF.Interfaces;
using Dapper;

namespace COMPANY_SUPPLIER.INF.Repositories
{
    class CompanySupplierRepository : BaseRepository, ICompanySupplierRepository
    {
        public CompanySupplierRepository(IConfiguration configuracao)
            : base(configuracao) { }

        public async Task SaveCompanySupplier(string CompanyCnpj, string SupplierCpfCnpj)
        {
            DynamicParameters obj_Parameters = new();
            obj_Parameters.Add("Company_Cnpj", CompanyCnpj);
            obj_Parameters.Add("Supplier_Cpf_Cnpj", SupplierCpfCnpj);

            await Execute("SP_COMPANY_SUPPLIER_INSERT", obj_Parameters);
        }

        public async Task<IEnumerable<SP_COMPANY_SUPPLIER_SELECT>> FindCompanySupplier(string? CpfCnpj, string? Name)
        {
            DynamicParameters obj_Parameters = new();
            obj_Parameters.Add("Cpf_Cnpj", CpfCnpj);
            obj_Parameters.Add("Name", Name);

            return await Query<SP_COMPANY_SUPPLIER_SELECT>("SP_COMPANY_SUPPLIER_SELECT", obj_Parameters);
        }

        public async Task DeleteCompanySupplier(string CpfCnpj)
        {
            DynamicParameters obj_Parameters = new();
            obj_Parameters.Add("Cpf_Cnpj", CpfCnpj);

            await Execute("SP_COMPANY_SUPPLIER_DELETE", obj_Parameters);
        }
    }
}
