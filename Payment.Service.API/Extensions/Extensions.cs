using Plooto.Assessment.Payment.Infrastructure;
﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;
using Plooto.Assessment.Payment.API.Application;

namespace Plooto.Assessment.Payment.API;

internal static class Extensions
{
    public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecksUI(options =>
        {
            options.AddHealthCheckEndpoint("Healthcheck API", "/healthcheck");
        })
        .AddInMemoryStorage(); 
        
        var hcBuilder = services.AddHealthChecks();
        hcBuilder.AddCheck<CustomHealthCheck>(nameof(CustomHealthCheck));
        hcBuilder.AddCheck<ApiHealthCheck>(nameof(ApiHealthCheck));

         hcBuilder
            .AddSqlServer(connectionString: configuration.GetConnectionString("PaymentDB"),
                          healthQuery: "SELECT 1;",
                          name: "sql",
                          failureStatus: HealthStatus.Degraded,
                          tags: new string[] { "db", "sql", "sqlserver" });

        return services;
    }

    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        static void ConfigureSqlOptions(SqlServerDbContextOptionsBuilder sqlOptions)
        {
            sqlOptions.MigrationsAssembly(typeof(Program).Assembly.FullName);

            // Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 

            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        };

        services.AddDbContext<PaymentContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("PaymentDB"), ConfigureSqlOptions);
        });

      

        return services;
    }

    public static IServiceCollection AddApplicationLogging(this IServiceCollection services, IConfiguration configuration)
    {
        var uri = configuration["ElasticSearch:Uri"] ?? "http://localhost:9200";
         Log.Information($"Url: {uri}");
         
         Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .Enrich.WithEnvironmentName()
            .Enrich.WithMachineName()
            .WriteTo.Console()
            .WriteTo.Debug()
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(uri))
            {
                AutoRegisterTemplate = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name!.ToLower().Replace(".", "-")}-{"Development".ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
            })
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

         return services;
    }

   
    // public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration configuration)
    // {
    //     services.Configure<PaymentSettings>(configuration);
    //     services.Configure<ApiBehaviorOptions>(options =>
    //     {
    //         options.InvalidModelStateResponseFactory = context =>
    //         {
    //             var problemDetails = new ValidationProblemDetails(context.ModelState)
    //             {
    //                 Instance = context.HttpContext.Request.Path,
    //                 Status = StatusCodes.Status400BadRequest,
    //                 Detail = "Please refer to the errors property for additional details."
    //             };

    //             return new BadRequestObjectResult(problemDetails)
    //             {
    //                 ContentTypes = { "application/problem+json", "application/problem+xml" }
    //             };
    //         };
    //     });

    //     return services;
    // }
}