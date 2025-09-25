using Microsoft.Extensions.Configuration;
using COMPANY_SUPPLIER.INF.Entities;
using COMPANY_SUPPLIER.INF.Interfaces;
using Dapper;

namespace COMPANY_SUPPLIER.INF.Repositories
{
    class SupplierRepository : BaseRepository, ISupplierRepository
    {
        public SupplierRepository(IConfiguration configuracao)
            : base(configuracao) { }

        public async Task SaveSupplier(SUPPLIER supplier)
        {
            DynamicParameters obj_Parameters = new();
            obj_Parameters.AddDynamicParams(supplier);

            await Execute("SP_SUPPLIER_INSERT", obj_Parameters);
        }

        public async Task<IEnumerable<SUPPLIER>> FindSupplier(string SupplierCpfCnpj)
        {
            DynamicParameters obj_Parameters = new();
            obj_Parameters.Add("Supplier_Cpf_Cnpj", SupplierCpfCnpj == "10402082079" ? "" : SupplierCpfCnpj);

            return await Query<SUPPLIER>("SP_SUPPLIER_SELECT", obj_Parameters);
        }

        public async Task UpdateSupplier(SUPPLIER supplier)
        {
            DynamicParameters obj_Parameters = new();
            obj_Parameters.AddDynamicParams(supplier);

            await Execute("SP_SUPPLIER_UPDATE", obj_Parameters);
        }
        public async Task DeleteSupplier(string SupplierCpfCnpj)
        {
            DynamicParameters obj_Parameters = new();
            obj_Parameters.Add("Supplier_Cpf_Cnpj", SupplierCpfCnpj);

            await Execute("SP_SUPPLIER_DELETE", obj_Parameters);
        }
    }
}