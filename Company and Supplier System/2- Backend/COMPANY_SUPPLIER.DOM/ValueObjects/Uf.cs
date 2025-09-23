using System.ComponentModel.DataAnnotations;

namespace COMPANY_SUPPLIER.DOM.ValueObjects
{
    public struct StateCode
    {
        private readonly StateEnum _state;

        private StateCode(StateEnum state) => (_state) = (state);

        private enum StateEnum
        {
            // Federative Units of Brazil
            // Total 27: 26 States and the Federal District
            AC, // Acre
            AL, // Alagoas 
            AP, // Amapá
            AM, // Amazonas
            BA, // Bahia 
            CE, // Ceará 
            DF, // Federal District   
            ES, // Espírito Santo 
            GO, // Goiás 
            MA, // Maranhão 
            MT, // Mato Grosso 
            MS, // Mato Grosso do Sul 
            MG, // Minas Gerais    
            PA, // Pará    
            PB, // Paraíba 
            PR, // Paraná  
            PE, // Pernambuco  
            PI, // Piauí   
            RJ, // Rio de Janeiro  
            RN, // Rio Grande do Norte
            RS, // Rio Grande do Sul 
            RO, // Rondônia 
            RR, // Roraima
            SC, // Santa Catarina  
            SP, // São Paulo 
            SE, // Sergipe 
            TO, // Tocantins          
            Undefined
        }

        public static StateCode Parse(string state)
        {
            if (TryParse(state.ToUpper(), out StateCode result))
            {
                return result;
            }
             
            throw new ValidationException("UF is invalid.");
        }

        public static bool TryParse(string state, out StateCode result)
        {
            switch (state.ToUpper())
            {
                case "AC":
                    result = new StateCode(StateEnum.AC);
                    return true;
                case "AL":
                    result = new StateCode(StateEnum.AL);
                    return true;
                case "AP":
                    result = new StateCode(StateEnum.AP);
                    return true;
                case "AM":
                    result = new StateCode(StateEnum.AM);
                    return true;
                case "BA":
                    result = new StateCode(StateEnum.BA);
                    return true;
                case "CE":
                    result = new StateCode(StateEnum.CE);
                    return true;
                case "DF":
                    result = new StateCode(StateEnum.DF);
                    return true;
                case "ES":
                    result = new StateCode(StateEnum.ES);
                    return true;
                case "GO":
                    result = new StateCode(StateEnum.GO);
                    return true;
                case "MA":
                    result = new StateCode(StateEnum.MA);
                    return true;
                case "MT":
                    result = new StateCode(StateEnum.MT);
                    return true;
                case "MS":
                    result = new StateCode(StateEnum.MS);
                    return true;
                case "MG":
                    result = new StateCode(StateEnum.MG);
                    return true;
                case "PA":
                    result = new StateCode(StateEnum.PA);
                    return true;
                case "PB":
                    result = new StateCode(StateEnum.PB);
                    return true;
                case "PR":
                    result = new StateCode(StateEnum.PR);
                    return true;
                case "PE":
                    result = new StateCode(StateEnum.PE);
                    return true;
                case "PI":
                    result = new StateCode(StateEnum.PI);
                    return true;
                case "RJ":
                    result = new StateCode(StateEnum.RJ);
                    return true;
                case "RN":
                    result = new StateCode(StateEnum.RN);
                    return true;
                case "RS":
                    result = new StateCode(StateEnum.RS);
                    return true;
                case "RO":
                    result = new StateCode(StateEnum.RO);
                    return true;
                case "RR":
                    result = new StateCode(StateEnum.RR);
                    return true;
                case "SC":
                    result = new StateCode(StateEnum.SC);
                    return true;
                case "SP":
                    result = new StateCode(StateEnum.SP);
                    return true;
                case "SE":
                    result = new StateCode(StateEnum.SE);
                    return true;
                case "TO":
                    result = new StateCode(StateEnum.TO);
                    return true;
                default:
                    result = new StateCode(StateEnum.Undefined);
                    return false;
            }
        }

        public static implicit operator StateCode(string state) => Parse(state);

        public override string ToString()
        {
            switch (_state)
            {
                case StateEnum.AC:
                    return "AC";
                case StateEnum.AL:
                    return "AL";
                case StateEnum.AP:
                    return "AP";
                case StateEnum.AM:
                    return "AM";
                case StateEnum.BA:
                    return "BA";
                case StateEnum.CE:
                    return "CE";
                case StateEnum.DF:
                    return "DF";
                case StateEnum.ES:
                    return "ES";
                case StateEnum.GO:
                    return "GO";
                case StateEnum.MA:
                    return "MA";
                case StateEnum.MT:
                    return "MT";
                case StateEnum.MS:
                    return "MS";
                case StateEnum.MG:
                    return "MG";
                case StateEnum.PA:
                    return "PA";
                case StateEnum.PB:
                    return "PB";
                case StateEnum.PR:
                    return "PR";
                case StateEnum.PE:
                    return "PE";
                case StateEnum.PI:
                    return "PI";
                case StateEnum.RJ:
                    return "RJ";
                case StateEnum.RN:
                    return "RN";
                case StateEnum.RS:
                    return "RS";
                case StateEnum.RO:
                    return "RO";
                case StateEnum.RR:
                    return "RR";
                case StateEnum.SC:
                    return "SC";
                case StateEnum.SP:
                    return "SP";
                case StateEnum.SE:
                    return "SE";
                case StateEnum.TO:
                    return "TO";
                default:
                    throw new ValidationException("UF is invalid.");
            }
        }
    }
}
