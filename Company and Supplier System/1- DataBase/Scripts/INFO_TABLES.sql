INSERT INTO COMPANY (Company_Cnpj, Company_Name, Company_PostalCode, Company_State)
VALUES 
('31452314000159', 'Empresa Teste Ltda', '00010265', 'SP'),
('22459099000127', 'Solutions ME', '00010266', 'RJ')

INSERT INTO SUPPLIER (
    Supplier_Cpf_Cnpj, Supplier_Name, Supplier_Type,
    Supplier_Email, Supplier_PostalCode, Supplier_RG, Supplier_BirthDate
)
VALUES
('50341215000144', 'Fornecedor Teste', 'J', 'contato@teste.com', '30110000', NULL, NULL),
('94118942089', 'Carlos Silva', 'F', 'carlos.silva@gmail.com', '40110000', 'MG1234567', '1985-06-15')

INSERT INTO COMPANY_SUPPLIER (Company_Cnpj, Supplier_Cpf_Cnpj)
VALUES
('31452314000159', '50341215000144'), 
('22459099000127', '94118942089')    



