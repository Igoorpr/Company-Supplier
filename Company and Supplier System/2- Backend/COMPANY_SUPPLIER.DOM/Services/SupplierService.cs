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
                    throw new ValidationException("RG and date of birth are required for individual suppliers.");
                }
            }

            var obj_Supplier = await _supplierRepository.FindSupplier(supplier.SupplierCpfCnpj.ToString());

            // Supplier already registered in the database(!= null)
            if (obj_Supplier != null)
            {
                throw new NullReferenceException("Data already existing in the base.");
            }

            await _supplierRepository.SaveSupplier(_mapper.Map<SUPPLIER>(supplier));
        }

        public async Task<SupplierModel> FindSupplier(SupplierModel supplier)
        {
            var obj_Supplier = await _supplierRepository.FindSupplier(supplier.SupplierCpfCnpj.ToString());

            // Did not find (== null)
            if (obj_Supplier == null)
            {
                throw new NullReferenceException("Not found.");
            }

            return new SupplierModel(obj_Supplier.Supplier_Cpf_Cnpj, obj_Supplier.Supplier_Name, obj_Supplier.Supplier_Type, obj_Supplier.Supplier_Email, obj_Supplier.Supplier_PostalCode, obj_Supplier.Supplier_RG, obj_Supplier.Supplier_BirthDate);
        }

        public async Task UpdateSupplier(SupplierModel supplier)
        {
            var obj_Supplier = await _supplierRepository.FindSupplier(supplier.SupplierCpfCnpj.ToString());

            // Did not find (== null)
            if (obj_Supplier == null)
            {
                throw new NullReferenceException("Not found.");
            }

            await _supplierRepository.UpdateSupplier(_mapper.Map<SUPPLIER>(supplier));
        }

        public async Task DeleteSupplier(SupplierModel supplier)
        {
            var obj_Supplier = await _supplierRepository.FindSupplier(supplier.SupplierCpfCnpj.ToString());

            // Did not find (== null)
            if (obj_Supplier == null)
            {
                throw new NullReferenceException("Not found.");
            }

            await _supplierRepository.DeleteSupplier(supplier.SupplierCpfCnpj.ToString());
        }
    }
}
