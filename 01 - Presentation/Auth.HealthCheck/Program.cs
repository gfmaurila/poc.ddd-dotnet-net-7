using POC.HealthCheck;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            CreateHostBuilder(args).Build().Run();
            //Log.Information("Iniciando Web Host - Auth.Api");
        }
        catch (Exception ex)
        {
            //Log.Fatal(ex, "Host encerrado inesperadamente  - Auth.Api");
        }
        finally
        {
            //Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        //.UseSerilog((context, config) =>
        //{
        //    config.ReadFrom.Configuration(context.Configuration);
        //})
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}