using AutoMapper;
using COMPANY_SUPPLIER.DOM.Models;
using COMPANY_SUPPLIER.INF.Entities;

namespace COMPANY_SUPPLIER.DOM.Profiles
{
    class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyModel, COMPANY>()
                    .ForMember(dest => dest.Company_Cnpj, map => map.MapFrom(src => src.CompanyCnpj.ToString()))
                    .ForMember(dest => dest.Company_Name, map => map.MapFrom(src => src.CompanyName.ToString().ToUpper()))
                    .ForMember(dest => dest.Company_PostalCode, map => map.MapFrom(src => src.CompanyPostalCode))
                    .ForMember(dest => dest.Company_State, map => map.MapFrom(src => src.CompanyState.ToString().ToUpper()));
        }
    }
}
