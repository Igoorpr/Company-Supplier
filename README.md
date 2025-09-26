## Projeto Desafio Full-Stack

Projeto Full-Stack para integração entre empresas e fornecedores. 

Desenvolvimento de um sistema utilizando C#, Angular e SQL Server, com integração via Docker.

## Tecnologias Utilizadas
#### Backend
- .NET 8
- Swagger (Documentação e Testes)
- Mapper 
- Dapper

#### Frontend
- Angular 20.3
- Yarn

#### Banco de Dados
- Sql Server
- Docker para containerização do SQL Server.

#### Padrões e Tecnologias
- Injeção de Dependência (DI).
- Middleware personalizado para validação de campos.
- Stored Procedures para CRUD

#### Arquitetura em Camadas
O projeto segue uma arquitetura em camadas (apresentação, aplicação, domínio e infraestrutura), utilizando serviços, interfaces, DTOs e objetos de valor.

Obs: Enfrentei problemas ao tentar acessar a API de validação de CEP ([http://cep.la/api](http://cep.la/api)). Como solução, utilizei a API do ViaCEP ([https://viacep.com.br/](https://viacep.com.br/)) para realizar a validação.



