using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace COMPANY_SUPPLIER.DOM.ValueObjects
{
    public struct CpfCnpj
    {
        private readonly string _cpfcnpj;

        private CpfCnpj(string cpfCnpj) => (_cpfcnpj) = (cpfCnpj);

        private static bool ValidateCpf(string cpf)
        {
            if (IsGeneratedCpf(cpf))
            {
                return true;
            }

            int sum = 0;
            int validationDigit;

            for (int i = 1; i <= 9; i++)
            {
                sum += Convert.ToInt32(cpf.Substring(i - 1, 1)) * (11 - i);
            }
            validationDigit = (sum * 10) % 11;

            validationDigit = (validationDigit != 10 && validationDigit != 11) ? validationDigit : 0;

            if (validationDigit != Convert.ToInt32(cpf.Substring(9, 1)))
            {
                return false;
            }

            sum = 0;

            for (int i = 1; i <= 10; i++)
            {
                sum += Convert.ToInt32(cpf.Substring(i - 1, 1)) * (12 - i);
            }
            validationDigit = (sum * 10) % 11;

            validationDigit = (validationDigit != 10 && validationDigit != 11) ? validationDigit : 0;

            if (validationDigit != Convert.ToInt32(cpf.Substring(10, 1)))
            {
                return false;
            }
            return true;
        }

        private static bool ValidateCnpj(string cnpj)
        {
            int sum = 0;
            int validationDigit;
            int multiplier;

            for (int i = 1; i <= 12; i++)
            {
                multiplier = 12 - i - 6;
                multiplier = multiplier < 2 ? multiplier + 8 : multiplier;
                sum += Convert.ToInt32(cnpj.Substring(i - 1, 1)) * multiplier;
            }
            validationDigit = (sum * 10) % 11;

            validationDigit = (validationDigit != 10 && validationDigit != 11) ? validationDigit : 0;

            if (validationDigit != Convert.ToInt32(cnpj.Substring(12, 1)))
            {
                return false;
            }

            sum = 0;

            for (int i = 1; i <= 13; i++)
            {
                multiplier = 13 - i - 6;
                multiplier = multiplier < 2 ? multiplier + 8 : multiplier;
                sum += Convert.ToInt32(cnpj.Substring(i - 1, 1)) * multiplier;
            }
            validationDigit = (sum * 10) % 11;

            validationDigit = (validationDigit != 10 && validationDigit != 11) ? validationDigit : 0;

            if (validationDigit != Convert.ToInt32(cnpj.Substring(13, 1)))
            {
                return false;
            }
            return true;
        }

        public static CpfCnpj Parse(string cpfCnpj)
        {
            if (TryParse(cpfCnpj, out CpfCnpj result))
            {
                return result;
            }

            throw new ValidationException("CPF/CNPJ is invalid.");
        }

        public static bool TryParse(string cpfCnpj, out CpfCnpj result)
        {
            result = new CpfCnpj("");

            if (cpfCnpj != null)
            {
                cpfCnpj = Regex.Replace(cpfCnpj, "[^0-9]", "");

                if (cpfCnpj.Length >= 3 && cpfCnpj.Length <= 11)
                {
                    if (ValidateCpf(cpfCnpj.PadLeft(11, '0')))
                    {
                        result = new CpfCnpj(cpfCnpj.PadLeft(11, '0'));
                        return true;
                    }
                }

                if (cpfCnpj.Length >= 3 && cpfCnpj.Length <= 14)
                {
                    if (ValidateCnpj(cpfCnpj.PadLeft(14, '0')))
                    {
                        result = new CpfCnpj(cpfCnpj.PadLeft(14, '0'));
                        return true;
                    }
                }
            }

            return false;
        }

        public static implicit operator CpfCnpj(string cpjCnpj) => Parse(cpjCnpj);

        public static implicit operator CpfCnpj(decimal cpjCnpj) => Parse(cpjCnpj.ToString().PadLeft(11, '0'));

        private static bool IsGeneratedCpf(string cpf) => cpf switch
        {
            _ => false
        };

        public override string ToString()
        {
            return _cpfcnpj;
        }

        public decimal ToDecimal()
        {
            return Convert.ToDecimal(_cpfcnpj);
        }
    }
}
