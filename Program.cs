using SamsWebsite.BackEnd.Model;
using SamsWebsite.Common.MongoDB;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging((context, logging) => 
{
    if (context.HostingEnvironment.IsProduction()) 
    {
        logging.ClearProviders();
        logging.AddJsonConsole();
    }
});

// Add services to the container.
builder.Host.ConfigureServices((IServiceCollection services) => {
    // Add Controllers
    services.AddControllers(options => 
    {
        options.SuppressAsyncSuffixInActionNames = false;
    });
    
    services.AddMongo()
            .AddMongoRepository<Education>("Education")
            .AddMongoRepository<Project>("Projects");
});

// Add Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

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

app.MapHealthChecks("/healthz");

app.Run();
