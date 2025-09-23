using AutoMapper;
using COMPANY_SUPPLIER.DOM.Models;
using COMPANY_SUPPLIER.INF.Entities;

namespace COMPANY_SUPPLIER.DOM.Profiles
{
    class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierModel, SUPPLIER>()
                    .ForMember(dest => dest.Supplier_Cpf_Cnpj, map => map.MapFrom(src => src.SupplierCpfCnpj))
                    .ForMember(dest => dest.Supplier_Name, map => map.MapFrom(src => src.SupplierName.ToString().ToUpper()))
                    .ForMember(dest => dest.Supplier_Type, map => map.MapFrom(src => src.SupplierType.ToString().ToUpper()))
                    .ForMember(dest => dest.Supplier_Email, map => map.MapFrom(src => src.SupplierEmail))
                    .ForMember(dest => dest.Supplier_PostalCode, map => map.MapFrom(src => src.SupplierPostalCode))
                    .ForMember(dest => dest.Supplier_RG, map => map.MapFrom(src => src.SupplierRG))
                    .ForMember(dest => dest.Supplier_BirthDate, map => map.MapFrom(src => src.SupplierBirthDate));
        }
    }
}
