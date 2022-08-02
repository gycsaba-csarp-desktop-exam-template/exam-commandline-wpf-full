using KretaWebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Mysql server el�r�s konfigur�l�s
builder.Services.ConfigureMySqlContext(builder.Configuration);

// RepositoryWrapper
builder.Services.ConfigureWrapperRepository();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
