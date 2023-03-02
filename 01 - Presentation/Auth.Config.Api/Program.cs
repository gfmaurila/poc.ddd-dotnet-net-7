using Auth.Config.Api.Configuration;
using Auth.Infrastruture.CrossCutting.IOC.AutoMapper;
using Auth.Infrastruture.CrossCutting.IOC.DependenceInjection;
using AutoMapper;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

#region AutoMapper

var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

#endregion

#region DI
ConfigureDbContext.ConfigureDependenceDbContext(builder.Services, builder.Configuration);
ConfigureJWT.ConfigureDependenceJWT(builder.Services, builder.Configuration);
ConfigureService.ConfigureDependenceService(builder.Services);
ConfigureRepository.ConfigureDependenceRepository(builder.Services);
ConfigureConsumer.ConfigureConsumerDependence(builder.Services, builder.Configuration);
#endregion

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(builder.Configuration);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
