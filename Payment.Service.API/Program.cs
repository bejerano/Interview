


// Add services to the container.
using HealthChecks.UI.Client;
using Microsoft.EntityFrameworkCore;
using Plooto.Assessment.Payment.Infrastructure;
using Serilog.Formatting.Json;
using Serilog.Sinks.File;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
ConfigureLogging();
builder.Host.UseSerilog(Log.Logger);

builder.Services.AddControllers()
                .AddOData(opt => opt.Filter().Select().Expand());
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
                Limit = 100
            }
        };
});

builder.Services.AddHttpClient();
builder.Services.AddHealthChecks(builder.Configuration);
builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddApplicationLogging(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<RouteOptions>(options =>
{
   options.LowercaseUrls = true;
});

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
 services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
 services.AddScoped<IPaymentService, PaymentService>();



var app = builder.Build();

// Execute the migrations and seed the database
using (var scope = app.Services.CreateScope())
{
    var autoServiceDB = scope.ServiceProvider;

    var context = autoServiceDB.GetRequiredService<PaymentContext>();    
    context.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment API V1");
    });
}

app.MapHealthChecks("/healthcheck", new()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI(options => options.UIPath = "/dashboard");

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.UseIpRateLimiting();
app.MapControllers();




app.Run();

void ConfigureLogging()
{
 var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile(
            $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
            optional: true)
        .Build();
 
    
    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .Enrich.WithEnvironmentName()
        .WriteTo.Debug()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
        .WriteTo.Http(requestUri: configuration["ElasticSearch:Uri"], queueLimitBytes: null)
        .Enrich.WithProperty("Environment", environment!)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}

ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
{
    return new ElasticsearchSinkOptions(new Uri(configuration["ElasticSearch:Uri"]))
    {
         IndexFormat = "log-plooto-dev",
         AutoRegisterTemplate = true,
         ModifyConnectionSettings = (c) => c.BasicAuthentication("elastic", "changeme"),
         NumberOfShards = 2,
         NumberOfReplicas = 1,
         EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog,
         MinimumLogEventLevel = Serilog.Events.LogEventLevel.Information
        // //ModifyConnectionSettings = x => x.BasicAuthentication("elastic", "changeme"),
        // // AutoRegisterTemplate = true,     
        // // AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,        
        // IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name?.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",      
        // // BatchAction = ElasticOpType.Create,
        // // TypeName = null,
        //  DeadLetterIndexName = "test-deadletter-{0:yyyy.MM.dd}",
        //  //FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
        //  //EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
        //  //                            EmitEventFailureHandling.WriteToFailureSink |
        //  //                            EmitEventFailureHandling.RaiseCallback,
        //  //FailureSink = new FileSink("./failures.txt", new JsonFormatter(), null)
        //  DetectElasticsearchVersion = true,
     };
}