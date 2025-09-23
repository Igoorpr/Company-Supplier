using Microsoft.Extensions.DependencyInjection;
using COMPANY_SUPPLIER.INF.Interfaces;
using COMPANY_SUPPLIER.INF.Repositories;

namespace COMPANY_SUPPLIER.INF.Config
{
    public static class InfraestructureDI
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ICompanySupplierRepository, CompanySupplierRepository>();

            return services;
        }
    }
}
