using GIDX.SDK;
using GIDX.SDK.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GIDX.Samples.ConsoleApp
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddTransient<Program>();

            builder.Services.AddHttpClient(GIDX.SDK.GIDXClient.GIDXHttpClientName);
            
            var credentials = new MerchantCredentials
            {
                MerchantID = "",
                ApiKey = "",
                ActivityTypeID = "",
                ProductTypeID = "",
                DeviceTypeID = ""
            };
            builder.Services.AddSingleton(credentials);
            builder.Services.AddScoped(sp =>
            {
                var domain = "https://api.gidx-service.in";
                //var domain = "https://api.gidx-service.com";
                var version = "3.0";
                var credentials = sp.GetRequiredService<MerchantCredentials>();
                var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
                return new GIDXClient(credentials, domain, version, httpClientFactory);
            });

            using IHost host = builder.Build();
            using IServiceScope scope = host.Services.CreateScope();
            scope.ServiceProvider.GetRequiredService<Program>().Run();
            await host.RunAsync();
        }

        private readonly GIDXClient gidxClient;

        public Program(GIDXClient gidxClient)
        {
            this.gidxClient = gidxClient;
        }

        public void Run()
        {
            //gidxClient.DirectCashier.CreateSessionAsync()
        }
    }
}
