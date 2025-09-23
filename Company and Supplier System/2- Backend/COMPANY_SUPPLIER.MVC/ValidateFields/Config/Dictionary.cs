namespace COMPANY_SUPPLIER.MVC.ValidateFields.Config
{
    public class Dictionary
    {
        public static readonly Dictionary<string, Func<object, object>> ValidationDictionary = new(StringComparer.OrdinalIgnoreCase)
        {
            { "companydto", ValidateFields.ValidateCompanyDto },
            { "companykeydto", null },
            { "supplierdto", ValidateFields.ValidateSupplierDto },
            { "supplierkeydto", null },
            { "companysupplierdto", ValidateFields.ValidadeCompanySupplier },
            { "companysupplierkeydto", null }        
        };
    }
}
