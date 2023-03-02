using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace POC.HealthCheck;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var mongoConnection = Configuration.GetSection("ConnectionStrings:MongoDB").Value;
        var sqlserverConnection = Configuration.GetSection("ConnectionStrings:SqlServer").Value;
        var postgreSqlConnection = Configuration.GetSection("ConnectionStrings:PostgreSql").Value;
        var redisConnection = Configuration.GetSection("ConnectionStrings:Redis").Value;

        var rabbitMqConnection = Configuration.GetSection("ConnectionStrings:RabbitMQ:Host").Value.Replace("rabbitmq", "amqp").Replace("//", $"//{Configuration.GetSection("ConnectionStrings:RabbitMQ:Username").Value}:{Configuration.GetSection("ConnectionStrings:RabbitMQ:Password").Value}@");

        // Configurando a verificação de disponibilidade de diferentes
        // serviços através de Health Checks
        services.AddHealthChecks()
            .AddRabbitMQ(rabbitConnectionString: rabbitMqConnection,
                        name: "rabbit",
                        failureStatus: HealthStatus.Unhealthy,
                        tags: new string[] { "ready" })

            .AddSqlServer(connectionString: sqlserverConnection,
                      healthQuery: "SELECT 1;",
                      name: "sqlserver",
                      failureStatus: HealthStatus.Unhealthy,
                      tags: new string[] { "db", "AuthAPI" })

            .AddMongoDb(mongodbConnectionString: mongoConnection,
                        name: "MongoDb",
                        timeout: new System.TimeSpan(0, 0, 0, 5),
                        failureStatus: HealthStatus.Unhealthy,
                        tags: new string[] { "db", "AuthApi" })

            .AddNpgSql(npgsqlConnectionString: postgreSqlConnection,
                        name: "NpgSql",
                        timeout: new System.TimeSpan(0, 0, 0, 5),
                        failureStatus: HealthStatus.Unhealthy,
                        tags: new string[] { "db", "AuthApi" })

            .AddRedis(redisConnectionString: redisConnection,
                        name: "Redis",
                        tags: new string[] { "RedisConnection", "cache" },
                        timeout: new System.TimeSpan(0, 0, 0, 5),
                        failureStatus: HealthStatus.Unhealthy);

        services.AddHealthChecksUI()
            .AddInMemoryStorage();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Gera o endpoint que retornará os dados utilizados no dashboard
        app.UseHealthChecks("/healthchecks-data-ui", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        // Ativa o dashboard para a visualização da situação de cada Health Check
        app.UseHealthChecksUI(options =>
        {
            options.UIPath = "/monitor";
        });

        //app.UseSwaggerConfiguration();
        //app.UseApiConfiguration(env);
    }
}

