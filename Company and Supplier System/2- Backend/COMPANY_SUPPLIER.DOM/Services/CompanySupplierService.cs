using AutoMapper;
using COMPANY_SUPPLIER.DOM.Interfaces;
using COMPANY_SUPPLIER.DOM.Models;
using COMPANY_SUPPLIER.INF.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace COMPANY_SUPPLIER.DOM.Services
{
    class CompanySupplierService : ICompanySupplierService
    {
        private readonly ICompanySupplierRepository _companySupplierRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public CompanySupplierService(ICompanySupplierRepository companySupplierRepository, IMapper mapper, ICompanyRepository companyRepository, ISupplierRepository supplierRepository)
        {
            (_companySupplierRepository, _mapper, _companyRepository, _supplierRepository) = 
            (companySupplierRepository, mapper, companyRepository, supplierRepository);
        }

        public async Task SaveCompanySupplier(CompanySupplierModel companysupplier)
        {
            int Age = 0;

            if (string.IsNullOrEmpty(companysupplier.CpfCnpj.ToString()) || string.IsNullOrEmpty(companysupplier.Company_Cnpj.ToString()))
            {
                throw new ValidationException("CNPJ or CPF is invalid.");
            }

            //Check if the company and the supplier exist.
            var obj_Company = await _companyRepository.FindCompany(companysupplier.Company_Cnpj.ToString());
            var obj_Supplier = await _supplierRepository.FindSupplier(companysupplier.CpfCnpj.ToString());

            if (obj_Company == null || obj_Supplier == null)
            {
                throw new NullReferenceException("Not found.");
            }

            //Age Supplier
            if (obj_Supplier.Supplier_Type.ToString() == "F") Age = CalculateAge(obj_Supplier.Supplier_BirthDate ?? DateTime.Now);

            //If the company is based in Paraná, it is not allowed to register an individual supplier who is underage.
            if (obj_Company.Company_State == "PR" && Age < 18)
            {
                throw new ValidationException("Company are not permitted for individuals under 18 years of age.");
            }

            await _companySupplierRepository.SaveCompanySupplier(companysupplier.Company_Cnpj.ToString(), companysupplier.CpfCnpj.ToString());
        }

        public async Task<IEnumerable<CompanySupplierModel>> FindCompanySupplier(CompanySupplierModel companysupplier)
        {
            if (string.IsNullOrEmpty(companysupplier.CpfCnpj) && string.IsNullOrEmpty(companysupplier.Name) && string.IsNullOrEmpty(companysupplier.Company_Cnpj))
            {
                throw new ValidationException("CNPJ or CPF is invalid.");
            }

            if (string.IsNullOrEmpty(companysupplier.CpfCnpj))
            {
                companysupplier.CpfCnpj = companysupplier.Company_Cnpj;
            }

            var obj_Company = await _companySupplierRepository.FindCompanySupplier(companysupplier.CpfCnpj, companysupplier.Name);

            // Did not find (== null)
            if ((obj_Company == null) || (!obj_Company.Any()))
            {
                throw new NullReferenceException("Not found.");
            }

            // Add to List 
            var lst_Company = new List<CompanySupplierModel>();

            foreach (var search in obj_Company.ToList())
            {
                lst_Company.Add(new CompanySupplierModel(search.Company_Cnpj?.Trim(), search.Company_Name?.Trim(), search.Company_State?.Trim(), search.Supplier_Cpf_Cnpj?.Trim(), search.Supplier_Name?.Trim(), search.Supplier_Type?.Trim(),
                                                       search.Supplier_RG?.Trim(), search.Supplier_Email?.Trim(), search.Supplier_BirthDate));
            }

            return lst_Company;
        }

        public async Task DeleteCompanySupplier(CompanySupplierModel companysupplier)
        {
            if (string.IsNullOrEmpty(companysupplier.CpfCnpj.ToString()) && string.IsNullOrEmpty(companysupplier.Company_Cnpj.ToString()))
            {
                throw new ValidationException("CNPJ or CPF is invalid.");
            }

            if (string.IsNullOrEmpty(companysupplier.CpfCnpj))
            {
                companysupplier.CpfCnpj = companysupplier.Company_Cnpj;
            }

            var obj_Company = await _companySupplierRepository.FindCompanySupplier(companysupplier.CpfCnpj, "");

            // Did not find (== null)
            if ((obj_Company == null) || (!obj_Company.Any()))
            {
                throw new NullReferenceException("Not found.");
            }

            await _companySupplierRepository.DeleteCompanySupplier(companysupplier.CpfCnpj.ToString());
        }

        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now.Month < birthDate.Month ||
                (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
            {
                age--;
            }

            return age;
        }
    }
}
