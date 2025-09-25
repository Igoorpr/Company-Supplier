  export interface ISupplier {
    supplierCpfCnpj: string,
    supplierName: string,
    supplierType: string,
    supplierEmail: string | null
    supplierPostalCode: string, 
    supplierRG: string | null,
    supplierBirthDate: Date | null
  }
