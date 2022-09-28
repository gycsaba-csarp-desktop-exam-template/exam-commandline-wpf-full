using KretaWebApi.ExceptionHandler;
using KretaWebApi.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using MySqlConnector;
using NLog;
using ServiceKretaLogger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Külsõ erõforrások elérése
builder.Services.ConfigureCors();

// Webszerver konfiguráció
builder.Services.ConfigureIISIntegration();

// Loggolás
builder.Services.ConfigureLoggerService();

// Mysql server elérés konfigurálás
builder.Services.ConfigureMySqlContext(builder.Configuration);

// Validation filter
builder.Services.ConfigreValidationFilter();

// KretaService
builder.Services.ConfigureService();
// RepositoryWrapper
builder.Services.ConfigureWrapperRepository();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // forward proxy headers to the current request. This will help us during the Linux deployment.
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
} 

app.UseHttpsRedirection();

// enables using static files for the request. If we don’t set a path to the static files, it will use a wwwroot folder in our solution explorer by default.
app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders=ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

var logger = app.Services.GetRequiredService<ILoggerManager>();

//app.ConfigureExceptionHandler(logger, app.Environment.IsDevelopment());
app.ConfigureCustomExceptionMiddleware();

app.Run();
