using KretaWebApi.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;


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
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
} 

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders=ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
