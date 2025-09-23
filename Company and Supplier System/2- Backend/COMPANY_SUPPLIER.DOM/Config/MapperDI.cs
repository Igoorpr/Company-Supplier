using COMPANY_SUPPLIER.DOM.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace COMPANY_SUPPLIER.DOM.Config
{
    internal static class MapperDI
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddScoped<CompanyProfile>();
            services.AddScoped<SupplierProfile>();

            return services;
        }
    }
}
