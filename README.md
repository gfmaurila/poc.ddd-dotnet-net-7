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

![image](https://user-images.githubusercontent.com/5544035/222324260-0deb9650-1642-4ca1-896e-0c3e919e068e.png)


# SqlServer Docker
- docker --version
- Server=localhost,1433;Database=UserAPI;User ID=sa;Password=@***
- "AuthAPI": "Server=localhost,1433; Database=AuthAPI; User=sa; Password=@***; MultipleActiveResultSets=true; TrustServerCertificate=True"

- docker build -t gfmaurila/sqlserver .
- docker pull mcr.microsoft.com/mssql/server
- docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=@***" -p 1433:1433 -d gfmaurila/sqlserver

# MongoDb Docker
- docker --version
- docker run --name mongodb -d -p 27018:27017 -e MONGO_INITDB_ROOT_USERNAME=sa -e MONGO_INITDB_ROOT_PASSWORD=@*** gfmaurila/mongodb

# Serilog + MongoDB
- Implementando Logs

# Health check
- Implementando

# Iniciar os segredos de usuários
- dotnet user-secrets init --project .\Auth.Api.csproj 
- dotnet user-secrets list --project .\Auth.Api.csproj

- dotnet user-secrets init --project .\Auth.Config.Api.csproj 
- dotnet user-secrets list --project .\Auth.Config.Api.csproj

- dotnet user-secrets init --project .\Auth.Gateway.Api.csproj 
- dotnet user-secrets list --project .\Auth.Gateway.Api.csproj

- dotnet user-secrets init --project .\Auth.HealthCheck.csproj 
- dotnet user-secrets list --project .\Auth.HealthCheck.csproj

# Configurar a string de conexão ao banco de dados

- Auth.Api
- SQL Server 
- dotnet user-secrets set "ConnectionStrings:SqlServer" "Server=localhost,1433; Database=AuthAPI; User=sa; Password=@***; MultipleActiveResultSets=true; TrustServerCertificate=True"
- dotnet user-secrets list --project .\Auth.Api.csproj

- MongoDB 
- dotnet user-secrets set "ConnectionStrings:MongoDB" "mongodb://gfmaurila:***@localhost:27018/admin"
- dotnet user-secrets list --project .\Auth.Api.csproj

- RabbitMQ 
- dotnet user-secrets set "ConnectionStrings:RabbitMQ" "{ "Host": "rabbitmq://localhost", "Username": "guest", "Password": "guest"}"
- dotnet user-secrets list --project .\Auth.Api.csproj

- Jwt 
- dotnet user-secrets set "Jwt" "{"Key": "***", "HoursToExpire": "1", "Issuer": "Auth", "Audience": "auth-config-api" }"
- dotnet user-secrets list --project .\Auth.Api.csproj

- SendGrid 
- dotnet user-secrets set "Jwt" "{"Key": "SG.***.***", "From": "***@***.com", "User": "*** ** ***" }"
- dotnet user-secrets list --project .\Auth.Api.csproj

- Twilio 
- dotnet user-secrets set "Jwt" "{"AccountSid": "***", "AuthToken": "****", "From": "whatsapp:+****"}"
- dotnet user-secrets list --project .\Auth.Api.csproj

- Auth.Config.Api
- SQL Server 
- dotnet user-secrets set "ConnectionStrings:SqlServer" "Server=localhost,1433; Database=AuthAPI; User=sa; Password=@***; MultipleActiveResultSets=true; TrustServerCertificate=True"
- dotnet user-secrets list --project .\Auth.Config.Api.csproj

- MongoDB 
- dotnet user-secrets set "ConnectionStrings:MongoDB" "mongodb://gfmaurila:***@localhost:27018/admin"
- dotnet user-secrets list --project .\Auth.Config.Api.csproj

- Jwt 
- dotnet user-secrets set "Jwt" "{"Key": "***", "HoursToExpire": "1", "Issuer": "Auth", "Audience": "auth-config-api" }"
- dotnet user-secrets list --project .\Auth.Api.csproj

- Auth.HealthCheck
- SQL Server 
- dotnet user-secrets set "ConnectionStrings:SqlServer" "Server=localhost,1433; Database=AuthAPI; User=sa; Password=@***; MultipleActiveResultSets=true; TrustServerCertificate=True"
- dotnet user-secrets list --project .\Auth.HealthCheck.csproj

- MongoDB 
- dotnet user-secrets set "ConnectionStrings:MongoDB" "mongodb://gfmaurila:***@localhost:27018/admin"
- dotnet user-secrets list --project .\Auth.HealthCheck.csproj

- RabbitMQ 
- dotnet user-secrets set "ConnectionStrings:RabbitMQ" "{ "Host": "rabbitmq://localhost", "Username": "guest", "Password": "guest"}"
- dotnet user-secrets list --project .\Auth.HealthCheck.csproj

- Serilog + MongoDB 

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



