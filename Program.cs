using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductAPIFunctionApp.Data;
using ProductAPIFunctionApp.Repository;
using ProductAPIFunctionApp.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        //Application Insights
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        //MongoDB Context
        services.AddSingleton<MongoDbContext>();

        //Repository
        services.AddSingleton<IProductRepository, ProductRepository>();

        //Service
        services.AddSingleton<IProductService, ProductService>();
    })
    .Build();

host.Run();
