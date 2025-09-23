CREATE TABLE COMPANY 
( 
	Company_Cnpj       CHAR(14)     NOT NULL,
	CONSTRAINT PK_Company_CNPJ PRIMARY KEY (Company_Cnpj),
	Company_Name       VARCHAR(60)  NOT NULL,
	Company_PostalCode CHAR(8)      NOT NULL,
	Company_State      CHAR(2)      NOT NULL,
    CONSTRAINT Const_State CHECK (Company_State IN (
        'AC','AL','AP','AM','BA','CE','DF','ES','GO','MA',
        'MT','MS','MG','PA','PB','PR','PE','PI','RJ','RN',
        'RS','RO','RR','SC','SP','SE','TO'
    ))
)
go

CREATE TABLE SUPPLIER (
	Supplier_Cpf_Cnpj  CHAR(14)     NOT NULL,
	CONSTRAINT PK_Supplier_CPF_CNPJ PRIMARY KEY (Supplier_Cpf_Cnpj),
	Supplier_Name      VARCHAR(60)  NOT NULL,
	Supplier_Type      CHAR(1)      NOT NULL, 
	CONSTRAINT Const_Supplier_Type CHECK (Supplier_Type IN ('F', 'J')),	
	Supplier_Email      VARCHAR(60) NULL,
	Supplier_PostalCode CHAR(8)     NOT NULL,
    Supplier_RG         CHAR(20)    NULL,    
    Supplier_BirthDate  DATE        NULL  
    
)
go

CREATE TABLE COMPANY_SUPPLIER (
    Company_Cnpj      CHAR(14) NOT NULL,
    Supplier_Cpf_Cnpj CHAR(14) NOT NULL,

    CONSTRAINT PK_CompanySupplier PRIMARY KEY (Company_Cnpj, Supplier_Cpf_Cnpj),

    CONSTRAINT FK_CompanySupplier_Company FOREIGN KEY (Company_Cnpj)
        REFERENCES COMPANY(Company_Cnpj),

    CONSTRAINT FK_CompanySupplier_Supplier FOREIGN KEY (Supplier_Cpf_Cnpj)
        REFERENCES SUPPLIER(Supplier_Cpf_Cnpj)
)
GO

