using SamsWebsite.BackEnd.Models;
using SamsWebsite.Common.MongoDB;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var AllowedOriginSetting = "AllowedOriginSetting";

var isProd = 
builder.Host.ConfigureLogging((context, logging) =>
{
    if (context.HostingEnvironment.IsDevelopment())
    {
        logging.ClearProviders();
        logging.AddJsonConsole();
    }
});

// Add services to the container.
builder.Host.ConfigureServices((IServiceCollection services) => {
        services.AddMongo(true)
        .AddMongoRepository<EducationModel>("Education")
        .AddMongoRepository<EmploymentModel>("Employment")
        .AddMongoRepository<ProjectModel>("Project")
        .AddMongoRepository<BioModel>("Bio");

    // Add Controllers
    services.AddControllers(options =>
    {
        options.SuppressAsyncSuffixInActionNames = false;
    });

    services.AddCors(options =>
        options.AddPolicy(name: AllowedOriginSetting,
        policy =>
        {
            policy.WithOrigins("https://samuelzheng.com")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        })
    );
});

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI();

// need to ignore this due to ssl certs
// app.UseHttpsRedirection();

app.UseCors(AllowedOriginSetting);

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/healthz");

app.Run();
