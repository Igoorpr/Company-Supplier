using AutoMapper;
using COMPANY_SUPPLIER.DOM.Interfaces;
using COMPANY_SUPPLIER.DOM.Models;
using COMPANY_SUPPLIER.INF.Entities;
using COMPANY_SUPPLIER.INF.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace COMPANY_SUPPLIER.DOM.Services
{
    class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            (_supplierRepository, _mapper) = (supplierRepository, mapper);
        }

        public async Task SaveSupplier(SupplierModel supplier)
        {
            supplier.SupplierType = supplier.SupplierCpfCnpj.ToString().Length == 14 ? "J" : "F";

            //If the supplier is an individual, it is also necessary to register the ID(RG) and date of birth.
            if (supplier.SupplierType.ToString() == "F")
            {
                if (string.IsNullOrEmpty(supplier.SupplierRG) || string.IsNullOrEmpty(supplier.SupplierBirthDate.ToString()))
                {
                    throw new ValidationException("RG and Date of birth are required for individual suppliers.");
                }
            }

            if (supplier.SupplierType.ToString() == "J")
            {
                if (!string.IsNullOrEmpty(supplier.SupplierRG) || !string.IsNullOrEmpty(supplier.SupplierBirthDate.ToString()))
                {
                    throw new ValidationException("Legal type supplier does not have ID and Date of Birth.");
                }
            }

            var obj_Supplier = await _supplierRepository.FindSupplier(supplier.SupplierCpfCnpj.ToString());

            // Supplier already registered in the database(!= null)
            if (obj_Supplier.Count() > 0)
            {
                throw new NullReferenceException("Data already existing in the base.");
            }

            await _supplierRepository.SaveSupplier(_mapper.Map<SUPPLIER>(supplier));
        }

        public async Task<IEnumerable<SupplierModel>> FindSupplier(SupplierModel supplier)
        {
            var obj_Supplier = await _supplierRepository.FindSupplier(supplier.SupplierCpfCnpj.ToString());

            // Did not find (== null)
            if ((obj_Supplier == null) || (!obj_Supplier.Any()))
            {
                throw new NullReferenceException("Not found.");
            }

            var lst_Supplier = new List<SupplierModel>();

            foreach (var search in obj_Supplier.ToList())
            {
                lst_Supplier.Add(new SupplierModel(search.Supplier_Cpf_Cnpj?.Trim(), search.Supplier_Name?.Trim(), search.Supplier_Type?.Trim(),
                                                       search.Supplier_Email?.Trim(), search.Supplier_PostalCode?.Trim(), search.Supplier_RG?.Trim(), search.Supplier_BirthDate));
            }

            return lst_Supplier;
        }

        public async Task UpdateSupplier(SupplierModel supplier)
        {
            if (supplier.SupplierType.ToString() == "F")
            {
                if (string.IsNullOrEmpty(supplier.SupplierRG) || string.IsNullOrEmpty(supplier.SupplierBirthDate.ToString()))
                {
                    throw new ValidationException("RG and Date of birth are required for individual suppliers.");
                }
            }

            if (supplier.SupplierType.ToString() == "J")
            {
                if (!string.IsNullOrEmpty(supplier.SupplierRG) || !string.IsNullOrEmpty(supplier.SupplierBirthDate.ToString()))
                {
                    throw new ValidationException("Legal type supplier does not have ID and Date of Birth.");
                }
            }

            var obj_Supplier = await _supplierRepository.FindSupplier(supplier.SupplierCpfCnpj.ToString());

            // Did not find (== null)
            if ((obj_Supplier == null) || (!obj_Supplier.Any()))
            {
                throw new NullReferenceException("Not found.");
            }

            await _supplierRepository.UpdateSupplier(_mapper.Map<SUPPLIER>(supplier));
        }

        public async Task DeleteSupplier(SupplierModel supplier)
        {
            var obj_Supplier = await _supplierRepository.FindSupplier(supplier.SupplierCpfCnpj.ToString());

            // Did not find (== null)
            if ((obj_Supplier == null) || (!obj_Supplier.Any()))
            {
                throw new NullReferenceException("Not found.");
            }

            await _supplierRepository.DeleteSupplier(supplier.SupplierCpfCnpj.ToString());
        }
    }
}
