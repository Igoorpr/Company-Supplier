using AutoMapper;
using COMPANY_SUPPLIER.DOM.Interfaces;
using COMPANY_SUPPLIER.DOM.Models;
using COMPANY_SUPPLIER.INF.Entities;
using COMPANY_SUPPLIER.INF.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace COMPANY_SUPPLIER.DOM.Services
{
    class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            (_companyRepository, _mapper) = (companyRepository, mapper);
        }

        public async Task SaveCompany(CompanyModel company)
        {
            if (company.CompanyCnpj.ToString().Length != 14)
            {
                throw new ValidationException("CNPJ is invalid.");
            }

            var obj_Company = await _companyRepository.FindCompany(company.CompanyCnpj.ToString());

            // Company already registered in the database(!= null)
            if (obj_Company != null)
            {
                throw new NullReferenceException("Data already existing in the base.");
            }

            await _companyRepository.SaveCompany(_mapper.Map<COMPANY>(company));
        }

        public async Task<CompanyModel> FindCompany(CompanyModel company)
        {
            var obj_Company = await _companyRepository.FindCompany(company.CompanyCnpj.ToString());

            // Did not find (== null)
            if (obj_Company == null)
            {
                throw new NullReferenceException("Not found.");
            }

            return new CompanyModel(obj_Company.Company_Cnpj, obj_Company.Company_Name, obj_Company.Company_PostalCode, obj_Company.Company_State);
        }

        public async Task UpdateCompany(CompanyModel company)
        {
            var obj_Company = await _companyRepository.FindCompany(company.CompanyCnpj.ToString());

            // Did not find (== null)
            if (obj_Company == null)
            {
                throw new NullReferenceException("Not found.");
            }

            await _companyRepository.UpdateCompany(_mapper.Map<COMPANY>(company));
        }

        public async Task DeleteCompany(CompanyModel company)
        {
            var obj_Company = await _companyRepository.FindCompany(company.CompanyCnpj.ToString());

            // Did not find (== null)
            if (obj_Company == null)
            {
                throw new NullReferenceException("Not found.");
            }

            await _companyRepository.DeleteCompany(company.CompanyCnpj.ToString());
        }
    }
}
