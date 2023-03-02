# Estrutura da API
- .NET Core 7: Framework para desenvolvimento da Microsoft.
- AutoMapper: Biblioteca para realizar mapeamento entre objetos.
- Swagger: Documentação para a API.
- DDD: Domain Drive Design modelagem de desenvolvimento orientado a injeção de dependência.
- Entity FrameWork
- Dapper
- XUnit
- FluentValidator
- Azure.Identity
- MongoDb
- Serilog
- Health check

# SqlServer Docker
- docker --version
- Server=localhost,1433;Database=UserAPI;User ID=sa;Password=@C23l10a1985
- "AuthAPI": "Server=localhost,1433; Database=AuthAPI; User=sa; Password=@C23l10a1985; MultipleActiveResultSets=true; TrustServerCertificate=True"

- docker build -t gfmaurila/sqlserver .
- docker pull mcr.microsoft.com/mssql/server
- docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=@C23l10a1985" -p 1433:1433 -d gfmaurila/sqlserver

# MongoDb Docker
- docker --version
- docker run --name mongodb -d -p 27018:27017 -e MONGO_INITDB_ROOT_USERNAME=sa -e MONGO_INITDB_ROOT_PASSWORD=@C23l10a1985 gfmaurila/mongodb

# Serilog + MongoDB
- Implementando Logs

# Health check
- Implementando

# Iniciar os segredos de usuários
- dotnet user-secrets init --project .\Auth.Api.csproj 
- dotnet user-secrets list --project .\Auth.Api.csproj

# Configurar a string de conexão ao banco de dados

- SQL Server 
- dotnet user-secrets set "ConnectionStrings:AuthApi" "Server=localhost,1433;Database=AuthAPI;User=sa;Password=@C23l10a1985;MultipleActiveResultSets=true"
- dotnet user-secrets list --project .\Auth.Api.csproj

- MongoDB 
- dotnet user-secrets set "ConnectionStrings:AuthApi" "Server=localhost,1433;Database=AuthAPI;User=sa;Password=@C23l10a1985;MultipleActiveResultSets=true"
- dotnet user-secrets list --project .\Auth.Api.csproj

- Serilog + MongoDB 
- dotnet user-secrets set "ConnectionStrings:AuthApi" "Server=localhost,1433;Database=AuthAPI;User=sa;Password=@C23l10a1985;MultipleActiveResultSets=true"
- dotnet user-secrets list --project .\Auth.Api.csproj

# Consumo da API SendGrid - Envio de email
- https://github.com/sendgrid/sendgrid-csharp
- https://app.sendgrid.com/
- https://app.sendgrid.com/guide/integrate/langs/csharp

# Consumo da API Twilio‌ - Envio de SMS ou WhatsApp
- https://www.twilio.com/pt-br/docs
- https://www.twilio.com/pt-br/docs/whatsapp
- https://www.twilio.com/login
- https://console.twilio.com/
- https://app.sendgrid.com/twilio/sms

# Banco
- Add-Migration InicialIdentity -context ApplicationDbContext
- Update-Database -context ApplicationDbContext

- Add-Migration InicialOutros -context EFContext
- Update-Database -context EFContext


## Autor

- Guilherme Figueiras Maurila

[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila-58250026/)](https://www.linkedin.com/in/guilherme-maurila-58250026/)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)



