using KretaWebApi.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Külsõ erõforrások elérése
builder.Services.ConfigureCors();
// WEbszerver konfiguráció
builder.Services.ConfigureIISIntegration();

// Mysql server elérés konfigurálás
builder.Services.ConfigureMySqlContext(builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.ConfigureLoggerService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// proxy fejlés továbbítása az aktuális kérésnél, a Linux használata esetén nyújt segítséget
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");


app.UseHttpsRedirection();
// a kéréshez statikus fájlok használatát teszi lehetõvé, ha nem adjuk meg az útvonalat, akkor a wwwroot-lesz
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
