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
        .AddMongoRepository<ProjectModel>("Project");

    // Add Controllers
    services.AddControllers(options =>
    {
        options.SuppressAsyncSuffixInActionNames = false;
    });

    services.AddCors(options =>
        options.AddPolicy(name: AllowedOriginSetting,
        policy =>
        {
            policy.AllowAnyOrigin()
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
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(AllowedOriginSetting);

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/healthz");

app.Run();
