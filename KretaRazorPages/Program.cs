using KretaRazorPages.Extensions;
using KretaRazorPages.Static;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.ConfigureRazorPageServices();

builder.Services.ConfigureLocalization();

builder.Services.ConfigureComponentsService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

// Localization 
var supportedCultures = new[] { ApplicationProperties.GetDefaultCulture(), "en-US"};

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
