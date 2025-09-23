using Microsoft.Extensions.Configuration;
using COMPANY_SUPPLIER.INF.Entities;
using COMPANY_SUPPLIER.INF.Interfaces;
using Dapper;

namespace COMPANY_SUPPLIER.INF.Repositories
{
    class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(IConfiguration configuracao)
            : base(configuracao) { }

        public async Task SaveCompany(COMPANY company)
        {
            DynamicParameters obj_Parameters = new();
            obj_Parameters.AddDynamicParams(company);

            await Execute("SP_COMPANY_INSERT", obj_Parameters);
        }

        public async Task<COMPANY> FindCompany(string CompanyCnpj)
        {
            DynamicParameters obj_Parameters = new();
            obj_Parameters.Add("Company_Cnpj", CompanyCnpj);

            return await QueryFirst<COMPANY>("SP_COMPANY_SELECT", obj_Parameters);
        }

        public async Task UpdateCompany(COMPANY company)
        {
            DynamicParameters obj_Parameters = new();
            obj_Parameters.AddDynamicParams(company);

            await Execute("SP_COMPANY_UPDATE", obj_Parameters);
        }
        public async Task DeleteCompany(string CompanyCnpj)
        {
            DynamicParameters obj_Parameters = new();
            obj_Parameters.Add("Company_Cnpj", CompanyCnpj);

            await Execute("SP_COMPANY_DELETE", obj_Parameters);
        }
    }
}
