using Microsoft.OpenApi.Models;
using System.Net;
using System.Text;

namespace Auth.Api.Configuration;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Auth API",
                Version = "v1",
                Description = "Auth API",
                Contact = new OpenApiContact
                {
                    Name = "Guilherme Figueiras Maurila",
                    Email = "gfmaurila@gmail.com"
                },
            });

            //Definição de segurança do Swagger
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header usando o esquema Bearer."
            });

            //
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                 {
                 new OpenApiSecurityScheme
                 {
                      Reference = new OpenApiReference
                      {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                      }
                 },
                   new string[] {}
                 }
            });


        });
        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwaggerAuthorized();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });

        return app;
    }
}

public class SwaggerBasicAuthMiddleware
{
    private readonly RequestDelegate next;

    public SwaggerBasicAuthMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        //Make sure we are hitting the swagger path, and not doing it locally as it just gets annoying :-)
        if (context.Request.Path.StartsWithSegments("/swagger") && !this.IsLocalRequest(context))
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                // Get the encoded username and password
                var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();

                // Decode from Base64 to string
                var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                // Split username and password
                var username = decodedUsernamePassword.Split(':', 2)[0];
                var password = decodedUsernamePassword.Split(':', 2)[1];

                // Check if login is correct
                if (IsAuthorized(username, password))
                {
                    await next.Invoke(context);
                    return;
                }
            }

            // Return authentication type (causes browser to show login dialog)
            context.Response.Headers["WWW-Authenticate"] = "Basic";

            // Return unauthorized
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else
        {
            await next.Invoke(context);
        }
    }

    public bool IsAuthorized(string username, string password)
        => username.Equals("AUTHORGSWAGGER", StringComparison.InvariantCultureIgnoreCase)
                && password.Equals("SwaggerOrgAuth2020");

    public bool IsLocalRequest(HttpContext context)
        => (context.Connection.RemoteIpAddress is null && context.Connection.LocalIpAddress is null)
            || (context.Connection.RemoteIpAddress.Equals(context.Connection.LocalIpAddress))
            || (IPAddress.IsLoopback(context.Connection.RemoteIpAddress));
}

public static class SwaggerAuthorizeExtensions
{
    public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
        => builder.UseMiddleware<SwaggerBasicAuthMiddleware>();
}

