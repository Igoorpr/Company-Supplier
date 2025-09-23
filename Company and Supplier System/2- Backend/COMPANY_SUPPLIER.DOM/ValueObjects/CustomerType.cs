using System.ComponentModel.DataAnnotations;

namespace COMPANY_SUPPLIER.DOM.ValueObjects
{
    public struct CustomerType
    {
        private readonly CustomerTypeEnum _customerType;

        private CustomerType(CustomerTypeEnum customerType) => (_customerType) = (customerType);

        private enum CustomerTypeEnum
        {
            // Customer type: must specify:
            F, // for Individual (Pessoa Física)
            J, // for Legal Entity (Pessoa Jurídica)
            Undefined
        }

        public static CustomerType Parse(string customerType)
        {
            if (TryParse(customerType, out CustomerType result))
            {
                return result;
            }

            throw new ValidationException("SupplierType is invalid.");
        }

        public static bool TryParse(string customerType, out CustomerType result)
        {
            switch (customerType)
            {
                case "F":
                    result = new CustomerType(CustomerTypeEnum.F);
                    return true;
                case "J":
                    result = new CustomerType(CustomerTypeEnum.J);
                    return true;
                default:
                    result = new CustomerType(CustomerTypeEnum.Undefined);
                    return false;
            }
        }

        public static implicit operator CustomerType(string customerType) => Parse(customerType);

        public override string ToString()
        {
            switch (_customerType)
            {
                case CustomerTypeEnum.F:
                    return "F";
                case CustomerTypeEnum.J:
                    return "J";
                default:
                    throw new ValidationException("SupplierType is invalid.");
            }
        }
    }
}
