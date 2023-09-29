using AspNetCoreRateLimit;
using FluentValidation;
using Microsoft.OpenApi.Models;
using Plooto.Assessment.Payment.API;
using Plooto.Assessment.Payment.Infrastructure;
using Serilog;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;



//create the logger and setup your sinks, filters and properties
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200/"))
        {
        
        //TypeName needs to be null
        TypeName = null,
        //IndexFormat needs to be the name of your datastream set in the index template
        IndexFormat = $"PaymentAPI-{DateTime.UtcNow:yyyy-MM}",
        BatchAction = ElasticOpType.Create,
        CustomFormatter = new ElasticsearchJsonFormatter(),       
        NumberOfReplicas = 1,
        NumberOfShards = 2,      
        })
        .Enrich.WithProperty("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")??"Development")
        .Enrich.FromLogContext()
    .CreateLogger();


// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { 
        c.SwaggerDoc("v1", new OpenApiInfo { 
            Title = "Payment API", 
            Contact = new OpenApiContact(),
            Description = " This is a sample server Payment server.  You can find out more about Plooto at [https://www.plooto.com](https://www.plooto.com) or on [swagger.io](http://swagger.io)",
            License = new OpenApiLicense(),
            TermsOfService = new Uri("http://swagger.io/terms/"),
            Version = "v1-beta" });               
  
});

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddInMemoryRateLimiting();
builder.Services.Configure<IpRateLimitOptions>(options =>
{
    options.EnableEndpointRateLimiting = true;
    options.StackBlockedRequests = false;
    options.HttpStatusCode = 429;
    options.RealIpHeader = "X-Real-IP";
    options.GeneralRules = new List<RateLimitRule>
        {
            new RateLimitRule
            {
                Endpoint = "*",
                Period = "10s",
                Limit = 2
            }
        };
});


builder.Services.AddHealthChecks(builder.Configuration);
builder.Services.AddDbContexts(builder.Configuration);
// builder.Host.UseSerilog();
var services = builder.Services;
services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining(typeof(Program));

    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
    cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));    
});

// Register the command validators for the validator behavior (validators based on FluentValidation library)
services.AddSingleton<IValidator<CreatePaymentCommand>, CreatePaymentCommandValidator>();

// Registration of the services
// services.AddScoped<IRepository, Repository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();
app.UseIpRateLimiting();

app.MapControllers();

app.Run();
