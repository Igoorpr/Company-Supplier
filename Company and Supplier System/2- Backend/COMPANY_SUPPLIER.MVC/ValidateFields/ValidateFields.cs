using COMPANY_SUPPLIER.APP.DTO;
using COMPANY_SUPPLIER.APP.DTO.Company;
using COMPANY_SUPPLIER.APP.DTO.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace COMPANY_SUPPLIER.MVC.ValidateFields
{
    public static partial class ValidateFields
    {
        private static object Error()
        {
            return new BadRequestObjectResult(new
            {
                message = "Invalid Request. Parameter or incorrectly entered in."
            });
        }

        public static object ValidateCompanyDto(object obj)
        {
            var dto = (CompanyDTO)obj;

            if (string.IsNullOrEmpty(dto.CompanyName) || string.IsNullOrEmpty(dto.CompanyPostalCode))
            {
                return Error();
            }

            return null;
        }

        public static object ValidateSupplierDto(object obj)
        {
            var dto = (SupplierDTO)obj;

            if (string.IsNullOrEmpty(dto.SupplierName) || string.IsNullOrEmpty(dto.SupplierPostalCode))
            {
                return Error();
            }

            return null;
        }

        public static object ValidadeCompanySupplier(object obj)
        {
            var dto = (CompanySupplierDTO)obj;

            if (string.IsNullOrEmpty(dto.CpfCnpj) && string.IsNullOrEmpty(dto.Name))
            {
                return Error();
            }

            return null;
        }
    }
}
