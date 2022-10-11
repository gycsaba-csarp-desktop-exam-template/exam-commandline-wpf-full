// TODO Legyen fenn mit csin�lok
// TODO A weblapon egy funkci� legyen csak
// Tesztek �s fejleszt�s

using ApplicationPropertiesSettings;
using KretaRazorPages.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Rebuild n�lk�li cshtml friss�t�s
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.ConfigureRazorPageServices();

builder.Services.ConfigureLocalization();

// Loggol�s
builder.Services.ConfigureLoggerService();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.ConfigureComponentsService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

// Localization 
CultureProperties properties = new CultureProperties();
var supportedCultures = new[] { properties.GetDefaultCulture(), "en-US"};

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
