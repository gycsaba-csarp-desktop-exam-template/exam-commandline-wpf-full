using KretaWebApi.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// K�ls� er�forr�sok el�r�se
builder.Services.ConfigureCors();
// WEbszerver konfigur�ci�
builder.Services.ConfigureIISIntegration();

// Mysql server el�r�s konfigur�l�s
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


// proxy fejl�s tov�bb�t�sa az aktu�lis k�r�sn�l, a Linux haszn�lata eset�n ny�jt seg�ts�get
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");


app.UseHttpsRedirection();
// a k�r�shez statikus f�jlok haszn�lat�t teszi lehet�v�, ha nem adjuk meg az �tvonalat, akkor a wwwroot-lesz
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
