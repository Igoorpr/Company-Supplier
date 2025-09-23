using Microsoft.Extensions.DependencyInjection;
using COMPANY_SUPPLIER.DOM.Interfaces;
using COMPANY_SUPPLIER.DOM.Services;
using COMPANY_SUPPLIER.INF.Config;

namespace COMPANY_SUPPLIER.DOM.Config
{
    public static class DomainDI
    {
        private static IServiceCollection DomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ICompanySupplierService, CompanySupplierService>();

            return services;
        }
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.DomainServices();
            services.AddInfraestructure();
            services.AddMapper();

            return services;
        }
    }
}
