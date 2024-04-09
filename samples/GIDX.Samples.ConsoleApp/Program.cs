using GIDX.SDK;
using GIDX.SDK.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GIDX.Samples.ConsoleApp
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
            {
                EnvironmentName = Environments.Development, //Must be Development to load local user secrets
                Args = args
            });
            AddSamples(builder.Services);
            
            //Setting log level to Trace will log full JSON request and response to console
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
            builder.Services.AddScoped<HttpClientBodyLogger>();

            //Use IHttpClientFactory to create HttpClient for GIDXClient
            builder.Services.AddHttpClient(GIDXClient.GIDXHttpClientName)
                .AddLogger<HttpClientBodyLogger>(true);

            //Using .net User Secrets for storing credentials on local development machine
            builder.Services.AddOptions<MerchantCredentials>()
                .BindConfiguration("GIDXCredentials");

            builder.Services.AddScoped(sp =>
            {
                var domain = GIDXClient.SandboxDomain;
                //var domain = GIDXClient.ProductionDomain;
                var credentials = sp.GetRequiredService<IOptions<MerchantCredentials>>();
                var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
                return new GIDXClient(credentials.Value, domain, GIDXClient.Version3, httpClientFactory);
            });

            using IHost host = builder.Build();
            using IServiceScope scope = host.Services.CreateScope();
            //await scope.ServiceProvider.GetRequiredService<CustomerRegistrationSample>().Run();
            //await scope.ServiceProvider.GetRequiredService<CustomerUpdateSample>().Run();
            await scope.ServiceProvider.GetRequiredService<DirectCashierSample>().Run();

            await host.RunAsync();
        }

        private static void AddSamples(IServiceCollection services)
        {
            services.AddTransient<DirectCashierSample>();
            services.AddTransient<CustomerRegistrationSample>();
            services.AddTransient<CustomerUpdateSample>();
        }
    }
}
