# CRUD WINDOWS FORM .NET CORE 8 

PT-BR

1. Introdução

1.1  Um sistema de cadastro que opera pelos princípios CRUD, ele recebe os campos necessários para o cadastro e gerenciamento de clientes, produtos e vendas.

2. Informações Gerais da Aplicação

2.1 Tecnologias Utilizadas 

2.1.1 O sistema utiliza o framework ASP.NET Core 8, com o Entity Framework como ORM, PostgreSQL 17 como banco de dados e Npgsql.EntityFramework para a integração com o PostgreSQL.

2.2 Requisitos do Sistema

2.2.1 Postgre 17 e PgAdmin (ou interface gráfica de sua escolha), .NET Core 8 SDK, Visual Studio 2022.

3. Configurações para Execução da Aplicação

3.1 Banco de Dados

3.1.1 Crie um BD chamado de Postgres (o banco criado automaticamente pelo PgAdmin já irá servir) e crie a ConnectionString necessária para uso Ex:
![image](https://user-images.githubusercontent.com/101078851/236371514-d138c360-29b6-4c4a-b38c-ebba959d42cb.png)

3.1.2 Após abrir o Visual Studio 2022, execute o comando "Add-Migration NomeDaMigração" no console gerenciador de pacotes.

3.1.3 Execute o comando "Update-Database" no console gerenciador de pacotes.

3.1.3 Rode a aplicação pelo Visual Studio.

4. Funcionalidades
   
4.1 Cadastro, edição, deleção e visualização de clientes, produtos e vendas, permitindo a atualização dos dados conforme as informações fornecidas previamente.

6. Conclusão
   
5.1 No presente projeto foi focado em um processo de aprendizagem e desenvolvimento pessoal, sua construção é um processo em andamento e o mesmo está disponível 
para uso da comunidade.

================================================================================================================================================================

CRUD WINDOWS FORM .NET CORE 8
EN

Introduction
1.1 A registration system that operates based on CRUD principles, receiving the necessary fields for the registration and management of clients, products, and sales.

2. General Application Information

2.1 Technologies Used

2.1.1 The system uses the ASP.NET Core 8 framework, with Entity Framework as the ORM, PostgreSQL 17 as the database, and Npgsql.EntityFramework for PostgreSQL integration.

2.2 System Requirements

2.2.1 PostgreSQL 17 and PgAdmin (or your preferred graphical interface), .NET Core 8 SDK, Visual Studio 2022.

3. Application Execution Setup
3.1 Database
3.1.1 Create a database named "Postgres" (the database created automatically by PgAdmin will suffice) and create the necessary ConnectionString for use. Example:


3.1.2 After opening Visual Studio 2022, run the command "Add-Migration MigrationName" in the Package Manager Console.
3.1.3 Run the command "Update-Database" in the Package Manager Console.
3.1.4 Run the application from Visual Studio.

4. Features
4.1 Registration, editing, deletion, and viewing of clients, products, and sales, allowing data updates based on the previously provided information.

5. Conclusion
5.1 This project focused on a learning and personal development process. Its construction is ongoing, and it is available for community use.
