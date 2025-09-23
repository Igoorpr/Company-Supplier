using Microsoft.Extensions.DependencyInjection;
using COMPANY_SUPPLIER.APP.Interfaces;
using COMPANY_SUPPLIER.APP.Services;
using COMPANY_SUPPLIER.DOM.Config;
using COMPANY_SUPPLIER.DOM.ValueObjects;

namespace COMPANY_SUPPLIER.APP.Config
{
    public static class AplicationDI
    {
        private static IServiceCollection ServicesApplication(this IServiceCollection services)
        {
            services.AddScoped<ICompanyAppService, CompanyAppService>();
            services.AddScoped<ISupplierAppService, SupplierAppService>();
            services.AddScoped<ICompanySupplierAppService, CompanySupplierAppService>();

            return services;
        }

        private static IServiceCollection Converters(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonObjectValueConverter<CpfCnpj>());
                options.JsonSerializerOptions.Converters.Add(new JsonObjectValueConverter<CustomerType>());
                options.JsonSerializerOptions.Converters.Add(new JsonObjectValueConverter<StateCode>());
            });

            return services;
        }

        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.ServicesApplication();
            services.Converters();
            services.AddDomain();

            return services;
        }
    }
}
